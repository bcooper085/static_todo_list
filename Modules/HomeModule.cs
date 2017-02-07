using Nancy;
using System.Collections.Generic;
using ToDoList.Objects;

namespace ToDoList
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["add_task.cshtml"];
      Get["/view_tasks"] = _ => {
        List<string> allTasks = Task.GetAll();
        return View["view_tasks.cshtml", allTasks];
      };
      Post["/task_added"] = _ => {
        Task newTask = new Task(Request.Form["new-task"]);
        newTask.Save();
        return View["task_added.cshtml", newTask];
      };
      Post["/tasks_cleared"] = _ => {
        Task.ClearAll();
        return View["tasks_cleared.cshtml"];
      };
    }
  }
}
