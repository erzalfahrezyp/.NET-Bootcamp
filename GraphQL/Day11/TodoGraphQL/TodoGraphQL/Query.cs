using TodoGraphQL.Models;

public class Query
{
    public IQueryable<TodoTable> GetTodo([Service] TodoGraphQlContext context) => context.TodoTables;
}
