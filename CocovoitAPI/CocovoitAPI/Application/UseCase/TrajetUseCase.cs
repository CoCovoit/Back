using CocovoitAPI.Business.Entity;
using CocovoitAPI.Business.Repository;

namespace CocovoitAPI.Application.UseCase;

public class TrajetUseCase : ITrajetUseCase
{
    private readonly ITrajetRespository repo;
    public TrajetUseCase(ITrajetRespository repo) {
        this.repo = repo;
    }
    public async Task<Trajet> Create(Trajet trajet)
    {
        return await repo.Create(trajet);
    }
}