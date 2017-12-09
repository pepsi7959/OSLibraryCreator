using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSCreator
{
    public enum Type{PEOPLE, LIGHT, SPACETYPE, VENTILATION};

    class Statistics {
        public int success = 0;
        public int fail = 0;
        public int invalid_value = 0;
        public int invalid_format = 0;
        public int total = 0;
        public String getString() { return "success: "+success+"\nfail: "+fail+"\ntotal: "+total; }
    }

    class Generator
    {
        public static String APPNAME = "Openstudio Library Creator";
        private String templatName = "";
        private String fileName = "";
        private const String fileExtenstion = "csv";
        private Statistics stat;
        private StringBuilder output = null;
        private int status = 0;

        public int Status { get => status; set => status = value; }

        public Generator(String templatName, String fileName) {
            this.templatName = templatName;
            this.fileName = fileName;
            this.stat = new Statistics();
            this.output = new StringBuilder();
        }

        public void generate() {
            String templateFile = "";
            Console.WriteLine("templateName: " + this.templatName);
            switch (templatName)
            {   
                case "People Definition":
                    templateFile = "Templates\\PeopleDefinition.oslt";
                    generatePeople(templateFile);
                    break;
                case "Light Definition":
                    templateFile = "Templates\\LightDefinition.oslt";
                    generateLight(templateFile);
                    break;
                case "Ventilation":
                    templateFile = "Templates\\Ventilation.oslt";
                    generateVentilation(templateFile);
                    break;
                case "Space Type":
                    templateFile = "Templates\\SpaceType.oslt";
                    generateSpaceType(templateFile);
                    break;
                default:
                    MessageBox.Show("Unknown " + templatName, Generator.APPNAME);
                    break;
            }
        }

        public void generatePeople(String templateFIle)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(templateFIle);
                String libraryFormat = sr.ReadToEnd();

                System.IO.StreamReader csv = new System.IO.StreamReader(fileName);

                String line = "";
                while ((line = csv.ReadLine()) != null)
                {
                    String[] token = line.Split(',');
                    double value = 0.0;
                    if (Double.TryParse(token[1], out value))
                    {
                        var lib = String.Format(libraryFormat, Guid.NewGuid(), token[0], value);
                        //Console.Write(lib);
                        output.Append(lib);
                        stat.success++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value: Cannot parse value: " + line);
                        stat.fail++;
                    }
                    stat.total++;
                }
                sr.Close(); 
                csv.Close();
                MessageBox.Show(stat.getString(), Generator.APPNAME);
            }
            catch (Exception ex) {
                MessageBox.Show("Sorry, Cannot create library: " + ex.ToString(), Generator.APPNAME);
            }
        }

        public void generateLight(String templateFIle)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(templateFIle);
                String libraryFormat = sr.ReadToEnd();

                System.IO.StreamReader csv = new System.IO.StreamReader(fileName);

                String line = "";
                while ((line = csv.ReadLine()) != null)
                {
                    String[] token = line.Split(',');
                    double value = 0.0;
                    if (Double.TryParse(token[1], out value))
                    {
                        var lib = String.Format(libraryFormat, Guid.NewGuid(), token[0], value);
                        //Console.Write(lib);
                        output.Append(lib);
                        stat.success++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value: Cannot parse value: " + line);
                        stat.fail++;
                    }
                    stat.total++;
                }
                sr.Close();
                csv.Close();
                MessageBox.Show(stat.getString(), Generator.APPNAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, Cannot create library: " + ex.ToString(), Generator.APPNAME);
            }
        }
        
        public void generateVentilation( String templateFile)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(templateFile);
                String libraryFormat = sr.ReadToEnd();

                System.IO.StreamReader csv = new System.IO.StreamReader(fileName);

                String line = "";
                while ((line = csv.ReadLine()) != null)
                {
                    //token[0] = Name
                    //token[1] = Outdoor Air Flow per Person {{m3/s-person}}
                    //token[2] = Outdoor Air Flow per Floor Area {{m3/s-m2}}
                    //token[3] = Outdoor Air Flow Rate {{m3/s}}
                    //token[4] = Outdoor Air Flow Air Changes per Hour {{1/hr}}

                    String[] token = line.Split(',');
                    double value1 = 0.0;
                    double value2 = 0.0;
                    double value3 = 0.0;
                    double value4 = 0.0;

                    if (Double.TryParse(token[1], out value1) 
                        && Double.TryParse(token[2], out value2)
                        && Double.TryParse(token[3], out value3)
                        && Double.TryParse(token[4], out value4))
                    {
                        var lib = String.Format(libraryFormat, Guid.NewGuid(), token[0], value1, value2, value3, value4);
                        //Console.Write(lib);
                        output.Append(lib);
                        stat.success++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value: Cannot parse value: " + line);
                        stat.fail++;
                    }
                    stat.total++;
                }
                sr.Close();
                csv.Close();
                MessageBox.Show(stat.getString(), Generator.APPNAME);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorry, Cannot create library: " + ex.ToString(), Generator.APPNAME);
            }

        }

        public void generateSpaceType( String templateFile)
        {

        }

        public void writeOutput(String filename) {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
            sw.Write(output.ToString());
            sw.Close();
        }
    }
}
