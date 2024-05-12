using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Worker_CRUD.Models;
using Worker_CRUD.Service;

namespace Worker_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly WorkerInterface _workerInterface;
        public WorkerController(WorkerInterface workerInterface)
        {
            _workerInterface = workerInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<WorkerModel>>>> GetWorkers()
        {
            return Ok(await _workerInterface.GetWorkers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<WorkerModel>>> GetWorkerById(int id)
        {
            ServiceResponse<WorkerModel> serviceResponse = await _workerInterface.GetWorkerById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<WorkerModel>>>> CreateWorker(WorkerModel novoWorker)
        {
            return Ok(await _workerInterface.CreateWorker(novoWorker));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<WorkerModel>>>> UpdateWorker(WorkerModel editadoWorker)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = await _workerInterface.UpdateWorker(editadoWorker);

            return Ok(serviceResponse);
        }

        [HttpPut("inactivateWorker")]
        public async Task<ActionResult<ServiceResponse<List<WorkerModel>>>> InactivateWorker(int id)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = await _workerInterface.InactivateWorker(id);

            return Ok(serviceResponse);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<WorkerModel>>>> DeleteWorker(int id)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = await _workerInterface.DeleteWorker(id);

            return Ok(serviceResponse);
        }
    }
}
