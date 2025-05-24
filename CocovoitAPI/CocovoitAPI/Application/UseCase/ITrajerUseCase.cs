using CocovoitAPI.Business.Entity;

namespace CocovoitAPI.Application.UseCase;

public interface ITrajetUseCase
{
    Task<Trajet> Create(Trajet trajet);
}