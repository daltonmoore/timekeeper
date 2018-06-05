using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace WindowsFormsApplication1
{
    class TimeKeeper
    {
        List<clockpair> clockinandoutpairs = new List<clockpair>();
        List<string> users = new List<string>();
        string[] flags = new string[50];
        int flagsLastIndex = 0;
        string usersfilepath, clockflagsfilepath, clockinfilepath, clockoutfilepath;


        //designates file paths for clockflags and users files, runs setup, and reads clockflags and users files into arrays
        public TimeKeeper()
        {
            usersfilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\timekeeper" + "\\users.txt";
            clockflagsfilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\timekeeper" + "\\clockflags.txt";
            clockinfilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\timekeeper" + "\\clockindata.txt";
            clockoutfilepath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\timekeeper" + "\\clockoutdata.txt";
            //setup();
            readfileintolist(users, usersfilepath);
            readfileintoarray(flags, clockflagsfilepath);
        }

        //don't think i need this anymore
        //runs initially to make sure users file exists
        string setup()
        {
            string output = "";

            if (File.Exists(usersfilepath))
            {
                return "Users File Already Exists";
            }
            //write to users file
            string[] lines = { "default0", "default1", "default2", "default3", "default4" };
            File.WriteAllLines(usersfilepath, lines);
            output += "Created users file\r\n";

            //write to clock flags file
            string[] lines2 = {"false", "false", "false", "false", "false"};
            File.WriteAllLines(clockflagsfilepath, lines2);
            output += "Created clockflags file\r\n";

            return output;
        }

        //checks if the given username is a duplicate, if not creates an entry in the users list and an entry in the flags array
        public string createuser(string user)
        {
            string output = "";
            if (checkduplicates(user))
            {
                output += user+" is a duplicate, enter another user name\r\n";
                //ask for new user name
            }
            else
            {
                output += "Successfully added user name "+user+"\r\n";
                users.Add(user);//add it to the arraylist, still needs to be saved at closing
                flags[flagsLastIndex] = "false";
                flagsLastIndex++;
            }
            return output;
        }

        //used to read clockflags values into flags array
        string readfileintoarray(Array arr, string filepath)
        {
            string output = "";
            try
            {
                output += "Trying to open a file to read\r\n";
                string[] temp = File.ReadAllLines(filepath);
                int i = 0;
                foreach (var item in temp)
                {
                    flags[i] = item;
                    i++; 
                    flagsLastIndex++;
                }
            }
            catch (Exception e)
            {
                output += "Failed to open file\r\n";
                output += e.StackTrace;
            }
            return output;
        }

        //basically only used by the users list
        string readfileintolist(List<string> arr, string filepath)
        {
            string output= "";
            try
            {
                output += "Trying to open a file to read\r\n";
                string[] temp = File.ReadAllLines(filepath);
                foreach(string item in temp)
                {
                    arr.Add(item);
                }
            }
            catch (Exception e)
            {
                output += "Failed to open file\r\n";
                output+=e.StackTrace;
            }
            return output;
        }

        //returns true if user is a duplicate and false if user is not
        bool checkduplicates(string user)
        {
            foreach (string item in users)
            {
                if (String.Equals(item, user))
                {
                    return true;
                }
            }
            return false;
        }

        //saves runtime arrays to text files
        public string cleanup()
        {
            string output = "";
            output += "Saving users array to users filepath at " + usersfilepath + "\r\n";
            File.WriteAllLines(usersfilepath, users.Cast<string>().ToArray());
            output += "Saving flags array to clockflags filepath at " + clockflagsfilepath + "\r\n";
            StreamWriter sw = new StreamWriter(clockflagsfilepath);
            for (int i = 0; i < flagsLastIndex; i++)
            {
                sw.WriteLine(flags[i]);
            }
            sw.Close();
            return output;
         }

        public string clockin(string user)
        {
            int check = checkflags(user, "clockin"); 
            if (check == -2)
            {
                return "User "+user+" is already clocked in\r\n";
            }
            else if (check == -1)
            {
                return "User " + user + " doesn't exist\r\n";
            }

            string localDate = DateTime.Now.ToString();
            StreamWriter sw = File.AppendText(clockinfilepath);
            sw.WriteLine(user+localDate);
            sw.Close();
            setflag(check, true);
            return "Clocked in " + user +"\r\n";
         }

        public string clockout(string user)
        {
            int check = checkflags(user, "clockout");
            if (check == -2)
            {
                return "User " + user + " is not clocked in\r\n";
            }
            else if (check == -1)
            {
                return "User " + user + " doesn't exist\r\n";
            }

            string localDate = DateTime.Now.ToString();
            StreamWriter sw = File.AppendText(clockoutfilepath);
            sw.WriteLine(user+localDate);
            sw.Close();
            setflag(check, false);
            return "Clocked out " + user + "\r\n";
        }

        void setflag(int userindex, bool val)
        {
            if (val == true)
            {
                flags[userindex] = "true";
            }
            else if (val == false)
            {
                flags[userindex] = "false";
            }
         }

        //if func is clockin this method returns -2 if the given user id is already clocked in, the index of the user if they are not clocked in, or -1 if the user doesn't exist in the array
        //if func is clockout this method returns the index of the given user if the given user id is already clocked in, -2 if they are not clocked in, or -1 if the user doesn't exist in the array
        int checkflags(string user, string func)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if(String.Equals(user, users[i]))
                {
                    if (String.Equals(flags[i], "true"))
                    {
                        if(string.Equals(func, "clockin"))
                        {
                            return -2;
                        }
                        else if (string.Equals(func, "clockout"))
                        {
                            return i;
                        }
                    }
                    else if (String.Equals(flags[i], "false"))
                    {
                        if (string.Equals(func, "clockin"))
                        {
                            return i;
                        }
                        else if (string.Equals(func, "clockout"))
                        {
                            return -2;
                        }
                    }
                }
            }
            return -1;
         }

        public string calculatehours(string user)
        {
            List<string> clockindatetimes = parsefilefordatetime(user, clockinfilepath);
            List<string> clockoutdatetimes = parsefilefordatetime(user, clockoutfilepath);
            List<TimeSpan> totals = new List<TimeSpan>();
            for (int i = 0; i < clockindatetimes.Count; i++)
            {
                clockinandoutpairs.Add(new clockpair(clockindatetimes[i], clockoutdatetimes[i]));
            }
            foreach (clockpair item in clockinandoutpairs)
            {
                DateTime d1 = Convert.ToDateTime(item.clockindatetime);
                DateTime d2 = Convert.ToDateTime(item.clockoutdatetime);
                TimeSpan diff = (d2 - d1);
                totals.Add(diff);
            }
            TimeSpan sum = TimeSpan.Zero;
            foreach (TimeSpan item in totals)
            {
                sum += item;
            }
            return sum.ToString()+"\r\n";
        }

        List<string> parsefilefordatetime(string user,string filepath)
        {
            string[] temp = File.ReadAllLines(filepath);
            List<string> output = new List<string>();

            foreach (string item in temp)
            {
                string grab = item.Substring(0, user.Length);
                if (string.Equals(grab, user))
                {
                    grab = item.Substring(user.Length);
                    output.Add(grab);
                }
            }
            return output;
        }

        struct clockpair
        {
            public string clockindatetime;
            public string clockoutdatetime;
            public clockpair(string clkin, string clkout)
            {
                clockindatetime = clkin;
                clockoutdatetime = clkout;
            }
        }
    }
}
