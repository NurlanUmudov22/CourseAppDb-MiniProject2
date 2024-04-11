using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Enums
{
    public enum OperationType
    {
        GetAllEducations = 1,
        GetByIdEducation= 2,
        DeleteEducation = 3,
        UpdateEducation = 4,
        SearchByNameEducation = 5,
        GetAllWithGroupsEducation = 6,
        SortWithCreatedDateEducation = 7,
        GetAllGroups = 8,
        GetByIdGroup = 9,
        DeleteGroup = 10,
        UpdateGroup = 11,
        SearchByNameGroup = 12,
        FilterByEduName = 13,
        GetAllWithEducationIdGroups = 14,
        SortWithCapacityGroup = 15
    }
}
