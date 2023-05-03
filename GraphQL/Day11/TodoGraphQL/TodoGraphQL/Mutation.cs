using TodoGraphQL.Models;

public class Mutation
{
    public TodoTable Create([Service] TodoGraphQlContext context, TodoTable todo)
    {
        var newTodo = new TodoTable { Description = todo.Description, Completed = todo.Completed};
        context.TodoTables.Add(newTodo);
        context.SaveChanges();
        return newTodo;
    }
    public TodoTable Update([Service] TodoGraphQlContext context, TodoTable todo, int id, string? description, bool? completed)
    {
        var Todo = context.TodoTables.FirstOrDefault(t => t.Id == id);
        if (Todo != null)
        {
            todo.Description = description ?? todo.Description;
            todo.Completed = completed ?? todo.Completed;
        }
        context.TodoTables.Update(Todo);
        context.SaveChanges();
        return Todo;
    }
    public TodoTable Delete([Service] TodoGraphQlContext context, int id)
    {
        var TodoDelete = context.TodoTables.FirstOrDefault(o => o.Id == id);
        if (TodoDelete != null)
        {
            context.TodoTables.Remove(TodoDelete);
            context.SaveChanges();
        }
        return TodoDelete;
    }
}
