using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TakeHomeTest
{
    class TwitterString
    {
        public List<string> Entity { get; set; }

        public string Link { get; set; }

        public string UserName { get; set; }

        public static int intReportCount = 0;

    

        public TwitterString(string input)
        {
            char[] charInput = input.ToCharArray();
            int firstChar = 0;
            int secondChar = 0;
            for (int i = 0; i < charInput.Length; i++)
            {
                if (charInput[i] == ':')
                {
                    firstChar = i;
                    break;
                }
            }
            for (int i = 0; i < charInput.Length; i++)
            { 
                if (charInput[i] == '@')
                {
                    secondChar = i;
                    break;
                }
            }
           
            int difference = (secondChar - firstChar) -3;
            UserName = input.Substring(secondChar+1);
            Link = input.Substring((firstChar + 2), difference);
            string entityContainer = input.Substring(0, firstChar);
            string[] stringArr = entityContainer.Split(' ');
            Entity = stringArr.ToList<string>();
        }

        public StringBuilder convertToHtml()
        {
            StringBuilder html = new StringBuilder();
            try
            {
                
                for (int i = 0; i < Entity.Count; i++)
                {
                    if (char.IsUpper(Entity[i], 0) && i != Entity.Count-1)
                    {
                        Entity[i] = " <strong>" + Entity[i] + "</strong> ";
                    }
                    else if (char.IsUpper(Entity[i], 0) && i == Entity.Count-1)
                    {
                        Entity[i] = " <strong>" + Entity[i] + ":</strong> ";
                    }
                    else
                    {
                        Entity[i] = " " + Entity[i];
                    }
                }
                int EntityCount = Entity.Count -1;
                if (Entity[EntityCount][1] != '<')
                {
                    Entity[EntityCount] = Entity[EntityCount] + ":";
                }
                Link = " <a href=\"" + Link + "\">" + Link + "</a>";
                UserName = " @<a href=\"http://twitter.com/" + UserName + "\">" + UserName + "</a>";

                for (int i = 0; i < Entity.Count; i++)
                {
                    html.Append(Entity[i]);
                }
                html.AppendLine(Link);
                html.AppendLine(UserName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return html;
        }

        public void PrintReport(StringBuilder html)
        {
            try
            {
                intReportCount++;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "HtmlOutput"));
                // A "using" statement will automatically close a file after opening it.
                // It never hurts to include a file.Close() once you are done with a file.
                using (StreamWriter writer = new StreamWriter(path + "\\HtmlOutput\\" + intReportCount.ToString() + "_Report.txt"))
                {
                    writer.WriteLine(html);
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Program Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool checkInput(string input)
        {
            bool isValid = true;
            char[] charArray = input.ToCharArray();
            int intColonCount = 0;
            int intAtCount = 0;
            int firstChar = 0;
            int secondChar = 0;

            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == ':')
                {
                    intColonCount++;
                }
                else if (charArray[i] == '@')
                {
                    intAtCount++;
                }
            }
            for (int i =0; i < charArray.Length; i++)
            {
                if (charArray[i] == ':')
                {
                    firstChar = i;
                    break;
                }
            }
            for (int i =0; i < charArray.Length; i++)
            {
                if (charArray[i] == '@')
                {
                    secondChar = i;
                    break;
                }
            }
            if (intColonCount != 2)
            {
                isValid = false;
            }
            else if (intAtCount != 1)
            {
                isValid = false;
            }
            else if (charArray[firstChar+1] != ' ' && charArray[firstChar+2] != 'h' && charArray[firstChar+3] != 't' && charArray[firstChar+4] != 't' && charArray[firstChar+5] != 'p')
            {
                isValid = false;
            }
            else if (firstChar > secondChar)
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
