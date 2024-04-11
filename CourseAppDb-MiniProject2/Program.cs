using CourseAppDb_MiniProject2.Controllers;
using Service.Helpers.Extensions;



EducationController educationController = new EducationController();

//await educationController.DeleteAsync();

//await educationController.GetAllAsync();

//await  educationController.GetByIdAsync();

//await educationController.SearchByNameAsync();

//await educationController.GetAllWithGroupsAsync();

//await educationController.SortWithCreatedDate();








GroupController groupController = new GroupController();
//await groupController.DeleteAsync();

//await groupController.GetAllAsync();

//await groupController.SearchByNameAsync();

//await groupController.GetByIdAsync();







static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one operation : \n  1. GetAll Educations \n " + " 2. GetById Education \n  3. Education delete \n  4. Education update \n  5. SearchByName Education \n  6. GetAllWithGroups Education \n  7. SortWithCreatedDate Education \n  8. GetAll Groups \n  9. GetById Group \n  10. Delete Group \n  11. Update Group \n  12. SearchByName Group \n  13. FilterByEduName  \n  14. GetAllWithEducationId Groups \n  15. SortWithCapacity Group \n ");

}

GetMenues();