using TaskModel = API.Models.Task;

namespace API.Services;

public class TaskService : ITaskService
{
    TasksContext _context;
    public TaskService(TasksContext context)
    {
        _context = context;
    }
    public IEnumerable<TaskModel> GetAll() {
        return _context.Tasks;
    }

    public async Task<bool> Save(TaskModel task){
        try {
            task.IdTask = Guid.NewGuid();
            task.CreationDate = DateTime.Now;

            await _context.AddAsync(task);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception) {
            return false;
        }
    }

    public async Task<bool> Update(Guid id, TaskModel task){
        try {
            var currentTask = _context.Tasks.Find(id);

            if(currentTask == null){
                return false;
            }

            currentTask.IdCategory = task.IdCategory; 
            currentTask.Title = task.Title;
            currentTask.Description = task.Description;
            currentTask.CulminationDate = task.CulminationDate;
            currentTask.Priority = task.Priority;

            _context.Update(currentTask);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception) {
            return false;
        }
    }

    public async Task<bool> Delete(Guid id){
        try {
            var currentTask = _context.Tasks.Find(id);

            if(currentTask == null){
                return false;
            }

            _context.Remove(currentTask);
            await _context.SaveChangesAsync();
            return true;
        } catch (Exception) {
            return false;
        }
    }
}

public interface ITaskService {
    IEnumerable<TaskModel> GetAll();
    Task<bool> Save( TaskModel task);
    Task<bool> Update(Guid id, TaskModel task);
    Task<bool> Delete(Guid id);
}