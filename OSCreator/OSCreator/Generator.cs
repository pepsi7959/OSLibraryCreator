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
                case "SpaceTypePlugIn":
                    templateFile = "Templates\\SpaceTypeTemplate.csv";
                    generateSpaceTypePlugIn(templateFile);
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
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(templateFile);
                String libraryFormat = sr.ReadToEnd();

                System.IO.StreamReader csv = new System.IO.StreamReader(fileName);

                String line = "";
                while ((line = csv.ReadLine()) != null)
                {
                    //token[0] = Name
                    String[] token = line.Split(',');

                    if ( token[0] != null )
                    {
                        var lib = String.Format(libraryFormat, Guid.NewGuid(), token[0]);
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

        public void generateSpaceTypePlugIn(String templateFile)
        {
            try
            {
                System.IO.StreamReader csv = new System.IO.StreamReader(templateFile);

                String SpaceTypeTemplate = "\"space_name\": \"{0}\",\n"
                                    + "\"alias_name\": \"{1}\",\n"
                                    + "\"cooling_setpoint_sch\": {2},\n"
                                    + "\"elec_equip_per_area\": {3},\n"
                                    + "\"elec_equip_sch\": {4},\n"
                                    + "\"gas_equip_per_area\": null,\n"
                                    + "\"gas_equip_sch\": null,\n"
                                    + "\"heating_setpoint_sch\": {5},\n"
                                    + "\"infiltration_per_area_ext\": {6},\n"
                                    + "\"infiltration_sch\": {7},\n"
                                    + "\"lighting_pri_spc_type\": \"{8}\",\n"
                                    + "\"lighting_sch\": \"{9}\",\n"
                                    + "\"lighting_sec_spc_type\": \"{10}\",\n"
                                    + "\"lighting_standard\": \"{11}\",\n"
                                    + "\"lighting_w_per_area\": {12},\n"
                                    + "\"lighting_w_per_person\": {13},\n"
                                    + "\"occupancy_activity_sch\": \"{14}\",\n"
                                    + "\"occupancy_per_area\": {15},\n"
                                    + "\"occupancy_sch\": \"{16}\",\n"
                                    + "\"rgb\": \"{17}_{18}_{19}\",\n"
                                    + "\"ventilation_ach\": {20},\n"
                                    + "\"ventilation_per_area\": {21},\n"
                                    + "\"ventilation_per_person\": {22},\n"
                                    + "\"ventilation_pri_spc_type\": \"{23}\",\n"
                                    + "\"ventilation_sec_spc_type\": \"{24}\",\n"
                                    + "\"ventilation_standard\": \"{25}\"\n";
                String line = "";
                int i = 0;
                Dictionary<String, LinkedList<String>> map = new Dictionary<String, LinkedList<String>>();

                while ((line = csv.ReadLine()) != null)
                {
                    //token[0] = Name
                    String[] token = line.Split(',');
                    Random rand = new Random(Guid.NewGuid().GetHashCode());
                    StringBuilder output = new StringBuilder();
                    if (token[0] != null && i++ > 0)
                    {
                        output.Clear();
                        var lib = String.Format("\"{0}\": {{\n", token[1]);
                        output.Append(lib);

                        lib = String.Format(SpaceTypeTemplate,
                            token[1], //space name
                            token[3], //alias
                            "null", //cooling_setpoint_sch
                            0.0, //elec_equip_per_area
                            "null", //elec_equip_sch
                            "null", //heating_setpoint_sch
                            0.0, //infiltration_per_area_ext
                            "null", //infiltration_sch
                            "", //lighting_pri_spc_type
                            token[13], //lighting_sch
                            "General", //lighting_sec_spc_type
                            "", //lighting_standard
                            Double.Parse(token[12]), //lighting_w_per_area
                            0.0, //lighting_w_per_person
                            token[14], //occupancy_activity_sch
                            Double.Parse(token[10]), //occupancy_per_area
                            token[15], //occupancy_sch
                            rand.Next()%255, rand.Next() % 255, rand.Next() % 255,//rgb
                            Double.Parse(token[8]), //ventilation_ach
                            Double.Parse(token[6]), //ventilation_per_area
                            Double.Parse(token[5]), //ventilation_per_person
                            "", //ventilation_pri_spc_type
                            "", //ventilation_sec_spc_type
                            "" //ventilation_standard
                            );

                        output.Append(lib);
                        output.Append("},");

                        LinkedList<String> outValue;
                        if (map.TryGetValue(token[0], out outValue))
                        {
                            map[token[0]].AddLast(output.ToString());
                        }
                        else {
                            map.Add(token[0], new LinkedList<string>());
                            map[token[0]].AddLast(output.ToString());
                        }

                        stat.success++;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Value: Cannot parse value: " + line);
                        stat.fail++;
                    }
                    stat.total++;
                }//end while


                foreach (var pair in map) {
                    Console.WriteLine("\"{0}\": {{", pair.Key);
                    var item = pair.Value.Last;
                    foreach( var str in pair.Value ){
                        Console.WriteLine("{0}", str);
                    }
                    Console.WriteLine("},");
                }
                MessageBox.Show(stat.getString(), Generator.APPNAME);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Sorry, Cannot create library: " + ex.ToString(), Generator.APPNAME);
            }

        }

        public void writeOutput(String filename) {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filename);
            sw.Write(output.ToString());
            sw.Close();
        }
    }
}
