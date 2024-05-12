using Microsoft.EntityFrameworkCore;
using Worker_CRUD.Context;
using Worker_CRUD.Models;

namespace Worker_CRUD.Service
{
    public class WorkerService : WorkerInterface
    {
        private readonly AppDbContext _context;
        public WorkerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<WorkerModel>>> GetWorkers()
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = new ServiceResponse<List<WorkerModel>>();

            try
            {
                serviceResponse.EmployeeData = _context.Worker.ToList();

                if (serviceResponse.EmployeeData.Count == 0)
                {
                    serviceResponse.Message = "Nenhum Funcionário localizado!";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<WorkerModel>> GetWorkerById(int id)
        {
            ServiceResponse<WorkerModel> serviceResponse = new ServiceResponse<WorkerModel>();

            try
            {
                WorkerModel Worker = _context.Worker.FirstOrDefault(x => x.Id == id);

                if (Worker == null)
                {
                    serviceResponse.EmployeeData = null;
                    serviceResponse.Message = "Funcionário não localizado!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                serviceResponse.EmployeeData = Worker;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<WorkerModel>>> CreateWorker(WorkerModel newWorker)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = new ServiceResponse<List<WorkerModel>>();

            try
            {
                if (newWorker == null)
                {
                    serviceResponse.EmployeeData = null;
                    serviceResponse.Message = "Informar dados do Funcionário!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Add(newWorker);
                await _context.SaveChangesAsync();

                serviceResponse.EmployeeData = _context.Worker.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<WorkerModel>>> UpdateWorker(WorkerModel updateWorker)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = new ServiceResponse<List<WorkerModel>>();

            try
            {
                WorkerModel Worker = _context.Worker.AsNoTracking().FirstOrDefault(x => x.Id == updateWorker.Id);

                if (Worker == null)
                {
                    serviceResponse.EmployeeData = null;
                    serviceResponse.Message = "Funcionário não localizado!";
                    serviceResponse.Success = false;
                }

                Worker.ChangeDate = DateTime.Now.ToLocalTime();

                _context.Worker.Update(updateWorker);
                await _context.SaveChangesAsync();

                serviceResponse.EmployeeData = _context.Worker.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<WorkerModel>>> InactivateWorker(int id)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = new ServiceResponse<List<WorkerModel>>();

            try
            {
                WorkerModel Worker = _context.Worker.FirstOrDefault(x => x.Id == id);

                if (Worker == null)
                {
                    serviceResponse.EmployeeData = null;
                    serviceResponse.Message = "Funcionário não localizado!";
                    serviceResponse.Success = false;
                }

                Worker.Activity = false;
                Worker.ChangeDate = DateTime.Now.ToLocalTime();

                _context.Worker.Update(Worker);
                await _context.SaveChangesAsync();

                serviceResponse.EmployeeData = _context.Worker.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<WorkerModel>>> DeleteWorker(int id)
        {
            ServiceResponse<List<WorkerModel>> serviceResponse = new ServiceResponse<List<WorkerModel>>();

            try
            {
                WorkerModel Worker = _context.Worker.FirstOrDefault(x => x.Id == id);

                if (Worker == null)
                {
                    serviceResponse.EmployeeData = null;
                    serviceResponse.Message = "Funcionário não localizado!";
                    serviceResponse.Success = false;

                    return serviceResponse;
                }

                _context.Worker.Remove(Worker);
                await _context.SaveChangesAsync();

                serviceResponse.EmployeeData = _context.Worker.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }

            return serviceResponse;
        }     
        
    }
}

