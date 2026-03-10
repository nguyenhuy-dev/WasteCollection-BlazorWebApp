using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WasteCollection.Entities.HuyNQ.Models;
using WasteCollection.Repositories.HuyNQ.Base;

namespace WasteCollection.Repositories.HuyNQ;

public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
{
    private readonly DbSet<SystemUserAccount> _systemUserAccountsDbSet;
    private readonly PasswordHasher<SystemUserAccount> _passwordHasher = new();

    public SystemUserAccountRepository()
    {
        _systemUserAccountsDbSet = _context.SystemUserAccounts;
    }

    public SystemUserAccountRepository(WasteCollectionDbContext context) => _context = context;

    /*
    public async Task<SystemUserAccount?> GetUserAsync(string email, string password)
    {
        return await _context.SystemUserAccounts
            .FirstOrDefaultAsync(u =>
                u.Email == email &&
                u.Password == password);

        //return await _context.SystemUserAccounts
        //    .FirstOrDefaultAsync(u =>
        //        u.UserName == userName &&
        //        u.Password == password);

        //return await _context.SystemUserAccounts
        //    .FirstOrDefaultAsync(u =>
        //        u.Phone == userName &&
        //        u.Password == password);

        //return await _context.SystemUserAccounts
        //    .FirstOrDefaultAsync(u =>
        //        u.EmployeeCode == userName &&
        //        u.Password == password);
    }
    */

    public async Task<SystemUserAccount?> GetUserWithEmailAndPasswordAsync(string email, string password)
    {
        var user = await _systemUserAccountsDbSet
            .FirstOrDefaultAsync(u => u.Email == email);
        if (user == null) return null;

        if (_passwordHasher.VerifyHashedPassword(user, user.HashedPassword, password) == PasswordVerificationResult.Failed)
            return null;

        return user;
    }
}
