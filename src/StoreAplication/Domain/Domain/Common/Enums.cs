using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Enums
    {
        public enum UserRoleEnum
        {
            SuperAdmin = 1,
            Admin = 2,
            Vendedor = 3
        }

        public enum CategoryEnum
        {
            HandTools = 1,
            PowerTools = 2,
            Locksmithing = 3,
            ConstructionHardware = 4,
            PaintAndAccessories = 5,
            GardeningAndOutdoors = 6,
            ProtectiveEquipment = 7,
            PlumbingSupplies = 8,
            Electrical = 9,
            HomeFixtures = 10,
            Others = 11
        }
    }
}
