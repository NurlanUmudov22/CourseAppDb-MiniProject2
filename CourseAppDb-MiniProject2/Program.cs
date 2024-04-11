using CourseAppDb_MiniProject2.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;



EducationController educationController = new EducationController();



//await educationController.DeleteAsync();

//await educationController.GetAllAsync();

//await  educationController.GetByIdAsync();

//await educationController.SearchByNameAsync();

await educationController.GetAllWithGroupsAsync();

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





//while (true)
//{
//    GetMenues();

//Operation: string operationStr = Console.ReadLine();

//    int operation;

//    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);

//    if (isCorrectOperationFormat)
//    {
//        switch (operation)
//        {
//            case (int)OperationType.GetAllEducations:
//                educationController.GetAllAsync(); 
//                break;
//            case (int)OperationType.GetByIdEducation:
//                educationController.GetByIdAsync();
//                break;
//            case (int)OperationType.DeleteEducation:
//                educationController.DeleteAsync();
//                break;
//            case (int)OperationType.UpdateEducation:
//                educationController.GetById();
//                break;
//            case (int)OperationType.SearchByNameEducation:
//                educationController.SearchByNameAsync();
//                break;
//            case (int)OperationType.GetAllWithGroupsEducation:
//                educationController.GetAllWithGroupsAsync();
//                break;
//            case (int)OperationType.SortWithCreatedDateEducation:
//                educationController.GetAll();
//                break;
//            case (int)OperationType.GetAllGroups:
//                groupController.GetAllAsync();
//                break;
//            case (int)OperationType.GetByIdGroup:
//                groupController.GetByIdAsync();
//                break;
//            case (int)OperationType.DeleteGroup:
//                groupController.DeleteAsync();
//                break;
//            case (int)OperationType.UpdateGroup:
//                groupController.StudentDelete();
//                break;
//            case (int)OperationType.SearchByNameGroup:
//                groupController.SearchByNameAsync();
//                break;
//            case (int)OperationType.FilterByEduName:
//                groupController.GetAllStudentsByGroupId();
//                break;
//            case (int)OperationType.GetAllWithEducationIdGroups:
//                groupController.SearchGroupsByName();
//                break;
//            case (int)OperationType.SortWithCapacityGroup:
//                groupController.SearchStudentsByNameOrSurname();
//                break;
//                default:
//                ConsoleColor.Red.WriteConsole("Operation format is wrong, please choose again");
//                goto Operation;

//        }
//    }
//    else
//    {
//        ConsoleColor.Red.WriteConsole("Operations is wrong, please add operation again ");
//        goto Operation;

//    }
//}

