using CourseAppDb_MiniProject2.Controllers;
using Service.Helpers.Extensions;



EducationController educationController = new EducationController();

//await educationController.DeleteAsync();

//await educationController.GetAllAsync();

//await  educationController.GetByIdAsync();

//await educationController.SearchByNameAsync();

//await educationController.GetAllWithGroupsAsync();

await educationController.SortWithCreatedDate();



//static void GetMenues()
//{
//    ConsoleColor.Cyan.WriteConsole("Choose one operation : \n  1. GetAll Educations \n " + " 2. GetById Education \n  3. Education delete \n  4. Education update \n  5. SearchByName Education \n  6. GetAllWithGroups Education \n  7. SortWithCreatedDate Education \n  8. Student create \n  9. Student update \n  10. Get student by Id \n  11. Student delete \n  12. Get student by age \n  13. Get all students by group Id \n  14. Search groups by name \n  15. Search students by name or surname \n  16. Get All Students");

//}
