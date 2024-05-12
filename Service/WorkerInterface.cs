using Worker_CRUD.Models;

namespace Worker_CRUD.Service
{
    public interface WorkerInterface
    {
        Task<ServiceResponse<List<WorkerModel>>> GetWorkers();
        Task<ServiceResponse<WorkerModel>> GetWorkerById(int id);
        Task<ServiceResponse<List<WorkerModel>>> CreateWorker(WorkerModel newWorker);
        Task<ServiceResponse<List<WorkerModel>>> UpdateWorker(WorkerModel updateWorker);
        Task<ServiceResponse<List<WorkerModel>>> InactivateWorker(int id);
        Task<ServiceResponse<List<WorkerModel>>> DeleteWorker(int id);        
    }
}
