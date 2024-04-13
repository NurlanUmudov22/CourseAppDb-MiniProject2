using CourseAppDb_MiniProject2.Controllers;
using Service.Helpers.Enums;
using Service.Helpers.Extensions;



EducationController educationController = new EducationController();



//await educationController.DeleteAsync();

//await educationController.GetAllAsync();

//await  educationController.GetByIdAsync();

//await educationController.SearchByNameAsync();

//await educationController.GetAllWithGroupsAsync();

//await educationController.SortWithCreatedDateAsync();


//await educationController.CreateEduAsync();









GroupController groupController = new GroupController();
//await groupController.DeleteAsync();

//await groupController.GetAllAsync();

//await groupController.SearchByNameAsync();

//await groupController.GetByIdAsync();


//await groupController.GetAllWithEducationIdAsync();

//await groupController.FilterByEduNameAsync();

 //await groupController.SortWithCapacityAsync();

//await groupController.CreateGroupAsync();
//await groupController.GetAllAsync();




//UserController userController = new UserController();
//await userController.GetAllAsync();


AccauntController accauntController = new AccauntController();
//await accauntController.RegisterAsync();

//await accauntController.Login();




static void GetMenues()
{
    ConsoleColor.Yellow.WriteConsole("\n Choose one operation : \n  1. GetAll Educations \n " + " 2. GetById Education \n  3. Education delete \n  4. Education update \n  5. SearchByName Education \n  6. GetAllWithGroups Education \n  7. SortWithCreatedDate Education \n  8. GetAll Groups \n  9. GetById Group \n  10. Delete Group \n  11. Update Group \n  12. SearchByName Group \n  13. FilterByEduName  \n  14. GetAllWithEducationId Groups \n  15. SortWithCapacity Group \n  16. Create Group \n  17  Create Education");

}

////GetMenues();

//static void LoginMenues()
//{
//    ConsoleColor.Yellow.WriteConsole(" Menu : \n  1. Register \n " + " 2. Login ");

//}
////LoginMenues();


//while (accauntController.LoginSuccess==false)
//{
//    LoginMenues();
//            Operation: string operationStr = Console.ReadLine();

//    int operation;

//    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);

//    if (isCorrectOperationFormat)
//    {
//        switch (operation)
//        {
//            case (int)LoginOperatType.Register:
//               await  accauntController.RegisterAsync();
//                break;
//            case (int)LoginOperatType.Login:
//               await  accauntController.LoginAsync();
//                break;
//            default:
//                ConsoleColor.Red.WriteConsole("Operation format is wrong, please choose again");
//                goto Operation;

//        }
//    }
//                else
//                {
//                   ConsoleColor.Red.WriteConsole("Operations is wrong, please add operation again ");
//                   goto Operation;

//                 }

//}




while (true)
{
    GetMenues();

Operation: string operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);

    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case (int)OperationType.GetAllEducations:
                await educationController.GetAllAsync();
                break;
            case (int)OperationType.GetByIdEducation:
                await educationController.GetByIdAsync();
                break;
            case (int)OperationType.DeleteEducation:
                await educationController.DeleteAsync();
                break;
            //case (int)OperationType.UpdateEducation:
            //   await educationController.GetById();
            //    break;
            case (int)OperationType.SearchByNameEducation:
                await educationController.SearchByNameAsync();
                break;
            case (int)OperationType.GetAllWithGroupsEducation:
                await educationController.GetAllWithGroupsAsync();
                break;
            case (int)OperationType.SortWithCreatedDateEducation:
                await educationController.SortWithCreatedDateAsync();
                break;
            case (int)OperationType.GetAllGroups:
                await groupController.GetAllAsync();
                break;
            case (int)OperationType.GetByIdGroup:
                await groupController.GetByIdAsync();
                break;
            case (int)OperationType.DeleteGroup:
                await groupController.DeleteAsync();
                break;
            //case (int)OperationType.UpdateGroup:
            //  await  groupController.StudentDelete();
            //    break;
            case (int)OperationType.SearchByNameGroup:
                await groupController.SearchByNameAsync();
                break;
            case (int)OperationType.FilterByEduName:
                await groupController.FilterByEduNameAsync();
                break;
            case (int)OperationType.GetAllWithEducationIdGroups:
                await groupController.GetAllWithEducationIdAsync();
                break;
            case (int)OperationType.SortWithCapacityGroup:
                await groupController.SortWithCapacityAsync();
                break;
            case (int)OperationType.CreateGroup:
                await groupController.CreateGroupAsync();
                break;
            case (int)OperationType.CreateEdu:
                await educationController.CreateEduAsync();
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation format is wrong, please choose again");
                goto Operation;

        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operations is wrong, please add operation again ");
        goto Operation;

    }
}

