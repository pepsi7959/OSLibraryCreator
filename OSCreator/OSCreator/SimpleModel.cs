using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSCreator
{
    class SpaceType
    {
        public String name = "";
        public String property = "";
        public SpaceType(String name, String property) {
            this.name = name;
            this.property = property;
        }
    }

    class SimpleModel
    {
        String buildingType = "";
        LinkedList<SpaceType> spaceTypes = new LinkedList<SpaceType>();

        public SimpleModel() {
        }

        public void addProperty(String name, String property) {
            this.spaceTypes.AddLast(new SpaceType(name, property));
        }

        public String toString() {
            String buildingTypeSTR= "";
            buildingTypeSTR += String.Format("\"{0}\":{", this.buildingType) ;
            foreach(SpaceType spcType in spaceTypes){
                buildingTypeSTR += String.Format("\"{0}\":{", spcType.name);
                buildingTypeSTR += String.Format("{0}", spcType.property);
                buildingTypeSTR += String.Format("},");
            }
            buildingTypeSTR += String.Format("}");
            return buildingType;
        }
    }
}
