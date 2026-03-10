using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Repositories.HuyNQ;
using WasteCollection.Services.HuyNQ.DTOs;

namespace WasteCollection.Services.HuyNQ;

public class SystemUserAccountService
{
    private readonly SystemUserAccountRepository _accountRepository;

    public SystemUserAccountService() => _accountRepository ??= new();

    /*
    public async Task<SystemUserAccount> GetUserAccountAsync(string userName, string password)
    {
        try
        {
            var user = await _accountRepository.GetUserAsync(userName, password) ?? 
                throw new NotFoundException("Username or password not correct.");

            return user;
        } 
        catch (Exception)
        {
            throw;
        }
    }
    */

    public async Task<SystemUserAccount?> LoginAsync(LoginRequest request)
    {
        try
        {
            var user = await _accountRepository.GetUserWithEmailAndPasswordAsync(request.Email, request.Password);
            return user;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
