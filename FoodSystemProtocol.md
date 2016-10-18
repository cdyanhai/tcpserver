#  1.协议概要 #

 外层协议消息头
 
    {
		"id"       : "消息uuid, 唯一标识
		"from"     : "来自"
   		"to"       : "去那"
		"type"     : "login（协议体类型标识）"
	    "ver"      : "1.0（协议版本）"
		"datetime" : "  2015-03-04 18:00:00 （时间戳）"
		"body"     : {
        			具体不同业务的协议体
   		}
	}




# 1.登录 login #

协议


    {
		"type"   : "* login",
   		"body"   : {
        "token"  : "密码  md5加密"
        "cv"	 : "客户端版本"
        "ct"	 : " 客户端类型家安卓,ios：
        "ip" 	 : "客户端ip--有需要数字验证的客户端必须传递"
        "dvc"    : "设备号",
       
    	}  
	}



# 2.登录返回 login_result #
协议

	{
		"type"   : "login_result",
   		"body"   : {
        "code"  : "返回码"
        "desc"	: "返回说明"
        
    	}  
	}
	code说明：
	0   表示登录成功
    
	100 用户名不存在
	101 密码出错
	102 登录出错
	103	系统异常



# 3.获取分类 food_type #
协议

上行

    {
		"type"	: 	"food_type"
		"body"	:{
					
		 }

    }

下行

    {
		"type"	:	"food_type"
		"body"	:{
				"types": [
				{
					"type_name"	: 	"分组名"
					"type_id"	:	"分组id"	
					"pid"	:	"父级id"
				},
				{
					......
				}
				
			]
		}
	}


# 4.获取分组下的数据 get_foods #
协议

上行

     {
		"type"	: 	"get_foods"
		"body"	:{
			"type_id":	"分组id，如果是0表示获全部数据"			
		 }

     }

下行

    {
		"type"	: 	"get_foods"
		"body"	:{
			"type_id":	"分组id
			"foods"	 : [
				{
					"fid"	: 123 "菜品id"
					"name"	: "菜名"
					"price"	:  88.8 "价线"
					"imgurl" :["www.imgurl.com", www.imgurl2.com]
					"desc"	:	"有生蔬菜"
				},
				{
					.....
				},
				...
			]		
		 }
	}

# 5.开单 submit_order #
协议

上行
     {
		"type"	: 	"submit_order"
		"body"	:{
			"desk_no":	1 桌号
			"number" ： 8 人数
 			"waiter" :	"服务员"
			"foods"	: [
				{
					"fid" 	:  123 "菜品id"
					"count"	:  1  数量		
					"remark":	"备注，比如少放辣椒"
				}
				，
				...

			]	
			
		 }

     }


# 6.开单返回结果 submit_order _result #
协议

下行

    {
		"type"   : "submit_order_result",
   		"body"   : {
		"order_id"	: 12345 订单id
        "code"  : "返回码"
        "desc"	: "返回说明"
        }  
	}

	code说明：
	0   表示下单成功
    非零 表示失败，原因说明在desc中
	


# 7. 结账 reckoning#
协议

上行

     {
		"type"	: 	"reckoning"
		"body"	:{
			"order_id"		:	123		订单id
			"desk_no"		:	1 		桌号
			"total_price" 	: 	100.0 	总金额
			"discount"		: 	9.5		折扣比例  1-10
			"payment"		:	95.0	应收金额
			"receipt"		:	100		实收金额
			"change"		:	5.00	找零	
 			"waiter" 		:	"服务员"
					
		 }

     }


# 8.结账结果 reckoning_result #
协议

下行

    {
		"type"   : "reckoning_result",
   		"body"   : {
		"order_id"	:	123		订单id
        "code"  	: "返回码"
        "desc"		: "返回说明"
        }  
	}
	code说明：
	0   表示结账成功
	非零 表示失败，原因说明在desc中
	
	

# 9. 修改订单 modify_order #
协议

上行
    {
		"type"	: 	"modify_order"
		"body"	:{
			"order_id"		:	123		订单id
			"desk_no"		:	1 桌号
 			"waiter" 		:	"服务员"
			"foods"	: [
				{
					"fid" 	:  123 "菜品id"
					"count"	:  1  数量		
					"remark":	"备注，比如少放辣椒"
				}
				，
				...

			]	
			
		 }

     }

下行
     {
		"type"   : "modify_order",
   		"body"   : {
		"order_id"	:	123		订单id
        "code"  	: "返回码"
        "desc"		: "返回说明"
        }  
	}

9. 删除订单
10. 获取订单
11. 获取订单详情
12. 修改用户信息  