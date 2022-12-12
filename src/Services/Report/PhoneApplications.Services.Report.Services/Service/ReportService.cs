using AutoMapper;
using PhoneApplications.Services.Report.Core.DTOs;
using PhoneApplications.Services.Report.Core.Entities;
using PhoneApplications.Services.Report.Core.Repositories;
using PhoneApplications.Services.Report.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApplications.Services.Report.Services.Service
{
    public class ReportService : BaseService<Reports>, IReportService
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _repository;
        public ReportService(IMapper mapper, IReportRepository repository) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ReportDTO> AddAsync()
        {
            var entity = new Reports
            {
                 Id=Guid.NewGuid(),
                 CreatedDate=DateTime.Now,
                 RequestedDate=DateTime.Now,
                 Status="Hazırlanıyor"
            };
            await _repository.AddAsync(entity);
            return _mapper.Map<ReportDTO>(entity);
        }

        public async Task<IEnumerable<ReportDTO>> GetListAsync()
        {
            return _mapper.Map<IEnumerable<ReportDTO>>(await _repository.GetAllAsync());
        }

        public Task<string> GetReportData(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CompleteReport(Guid id, string filepath)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null) return false;
            entity.Status = "Tamamlandı";
            entity.FilePath = filepath;
            entity.LastModifiedDate=DateTime.Now;
            _repository.Update(entity);
            return true;
        }
    }
}
