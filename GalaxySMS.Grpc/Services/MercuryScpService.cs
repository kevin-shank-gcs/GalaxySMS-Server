using System.Reflection;
using GalaxySMS.Data.NetCore;
using GalaxySMS.Data.NetCore.Interfaces;
using GalaxySMS.Data.NetCore.Repositories;
using GalaxySMS.Grpc;
using GCS.Core.Common.Contracts;
using Grpc.Core;

namespace GalaxySMS.Grpc.Services;

public class MercuryScpService : Grpc.MercuryScpService.MercuryScpServiceBase
{
    private readonly ILogger<MercuryScpService> _logger;
    private readonly IEfcRepository _genericRepository;
    private readonly IGalaxySMSDbContext _dbContext;

    public MercuryScpService(ILogger<MercuryScpService> logger, IEfcRepository genericRepository, IGalaxySMSDbContext dbContext)
    {
        _logger = logger;
        _genericRepository = genericRepository;
        _dbContext = dbContext;
    }

    public override Task<GetScpsReply> GetScps(GetScpsRequest request, ServerCallContext context)
    {
        var results = new GetScpsReply()
        {
            Status = new ReplyStatus(),
            PageData = new PagedResult()
        };
        //return await _genericRepository.SelectAllAsync<Merc>();
        return Task.FromResult(results);
    }
}

