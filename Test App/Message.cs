using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace testerApp
{
    public class Message
    {
        private string id;
        private string from;
        private string to;
        private string datetime;
        private string type;
        private string ver;
        private SubMessage body;

        public string From
        {
            get { return from; }
            set { from = value; }
        }

        public string To
        {
            get { return to; }
            set { to = value; }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Datetime
        {
            get { return datetime; }
            set { datetime = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Ver
        {
            get { return ver; }
            set { ver = value; }
        }

        public testerApp.SubMessage Body
        {
            get { return body; }
            set { body = value; }
        }

        public bool Deserialize(string data)
        {
            var obj = JsonConvert.DeserializeObject(data) as JObject;
            from = (string)obj["from"];
            to = (string)obj["to"];
            id = (string)obj["id"];
            type = (string)obj["type"];
            ver = (string)obj["ver"];
            datetime = (string)obj["datetime"];
            body = MessageFactory.CreateMessage(type);
            if(body != null)
                body.Deserialize(obj["body"].ToString());
            
            return true;
        }

        public string Serialize()
        {
            JObject obj = new JObject();
            obj["from"] = from;
            obj["to"] = to;
            obj["id"] = id;
            obj["type"] = type;
            obj["ver"] = ver;
            obj["datetime"] = datetime;
            obj["body"] = body.Serialize();
            return obj.ToString();
        }

    }

    public interface SubMessage
    {
        bool Deserialize(string data);
        JObject Serialize();
    }

    class LoginMessage : SubMessage
    {
        private string name;
        private string pwd;
        private string os;
        public bool Deserialize(string data)
        {
            var obj = JsonConvert.DeserializeObject(data) as JObject;
            name = (string)obj["name"];
            pwd = (string)obj["pwd"];
            os = (string)obj["os"];
            //os.Contains()
            return true;
        }

        public JObject Serialize()
        {
            JObject obj = new JObject();
            obj["name"] = name;
            obj["pwd"] = pwd;
            obj["os"] = os;
            return obj;
        }
                

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        public string Os
        {
            get { return os; }
            set { os = value; }
        }
    }

    struct Food_Info
    {
        public string name;
        public List<string> imgurl;
        public float price;
        public string desc;
    }

    class GetFoodsMsg : SubMessage
    {
        private List<Food_Info> foods;
        private int type_id;

        public List<Food_Info> Foods
        {
            get { return foods; }
            set { foods = value; }
        }

        public int Type_id
        {
            get { return type_id; }
            set { type_id = value; }
        }

        public bool Deserialize(string data)
        {
            var obj = JsonConvert.DeserializeObject(data) as JObject;
            type_id = (int)obj["type_id"];
            //os.Contains()
            foods = new List<Food_Info>();
            JArray a = (JArray)obj["foods"];
            foods = a.ToObject<List<Food_Info>>();
            return true;
        }

        public JObject Serialize()
        {
            JObject obj = new JObject();
            obj["type_id"] = type_id;
            obj["foods"] = JArray.FromObject(foods);
            return obj;
        }
    }
}
