using ConsoleWebAPI.Models;
using ConsoleWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Commented Code

        /*List<Account> accounts = null;
        public AccountController()
        {
            this.accounts = new List<Account>()
            {
                new Account() {AccountID = 1234, AccountTitle="Salman Abbas" },
                new Account() { AccountID = 45678, AccountTitle = "Syed Rizvi" }
            };
        }

        [Route("", Name = "getall")]
        public IActionResult GetAccounts()
        {

            return Ok(accounts);
        }

        [Route("test")]
        public IActionResult GetAccountTest()
        {
            return LocalRedirect("~/api/account");
        }

        [Route("202Code")]
        public IActionResult Get202Accounts()
        {
            //return Accepted("~/api/account/");
            //return AcceptedAtAction("GetAccounts");
            return AcceptedAtRoute("getall");
        }

        [Route("BadReqTest/{account_title}")]
        public IActionResult Get400Accounts(string account_title)
        {
            if (!account_title.Contains("salman"))
            {
                return BadRequest(
                    new ResponseError() { ErrorCode = 48, ErrorMessage = "Some thing goes wrong, please try again later" }
                    );
            }
            else
            {
                return Ok(accounts);
            }
        }

        [Route("{account_id:int}")]
        public IActionResult GetAccountbyId(int account_id)
        {
            if(account_id == 0)
            {
                return BadRequest();
            }

            var account = accounts.FirstOrDefault(x => x.AccountID == account_id);

            if (account == null)
                return NotFound();
            
            return Ok(account);
        }

        [HttpPost("")]
        public IActionResult GetAccount(Account account)
        {
            accounts.Add(account);

            //return Created("~api/account/"+ account.AccountID, account);
            return CreatedAtAction("GetAccountbyId", new { account_id = account.AccountID }, account);
        }*/

        #endregion

        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository;
        }

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp([FromBody] SignUpModel signUpModel)
        {
            var result =  await this._accountRepository.SignUpAsync(signUpModel);

            if (result.Succeeded)
            {
                return Ok(result.Succeeded);
            }

            return Unauthorized();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] SignInModel signInModel)
        {
            var result = await _accountRepository.LoginAsync(signInModel);

            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized();
            }

            return Ok(result);
        }
    }
}
