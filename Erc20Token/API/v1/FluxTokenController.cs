using System;
using System.Numerics;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using FluxToken.Contracts.Ethereum;
using FluxToken.Data.DTO.Request;
using FluxToken.Infrastructure.Configs;
using FluxToken.Services;
using FluxToken.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Nethereum.Geth;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;

namespace FluxToken.API.v1
{
    [Route("api/v1/token")]
    [ApiController]
    public class FluxTokenController : ControllerBase
    {
        #region Private Variables
        private readonly IFluxTokenService _fluxTokenService;
        private readonly AppConfig _appConfig;
        #endregion

        #region Constructor
        public FluxTokenController(IFluxTokenService fluxTokenService, IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig.Value
                            ?? throw new ArgumentNullException(nameof(appConfig));
            _fluxTokenService = fluxTokenService
                            ?? throw new ArgumentNullException(nameof(fluxTokenService));
        }
        #endregion

        [HttpGet("deploy")]
        public async Task<ApiResponse> Deploy()
        {
            var fluxTokenDeployment = new FluxTokenDeployment();
            // read file
            // var ksJson = System.IO.File.ReadAllText(_appConfig.KSFilename);
            // var account = new ManagedAccount(_appConfig.KSSenderAddress, _appConfig.KSPassword);
            // var web3 = new Web3Geth(acc);
            var acc = new Account(_appConfig.KSPrivateKey);
            var web3 = new Web3(acc, "https://ropsten.infura.io/v3/4d86f0f263a847209212303805f5b104");
            var contractReceipt = await FluxTokenService.DeployContractAndWaitForReceiptAsync(web3, fluxTokenDeployment);
            return new ApiResponse(contractReceipt.ContractAddress);
        }

        /// <summary>
        /// Gets the name of the Token.
        /// </summary>
        [HttpGet("name")]
        public async Task<ApiResponse> GetName()
        {
            var name = await _fluxTokenService.NameQueryAsync();
            return new ApiResponse(name);
        }

        /// <summary>
        /// Gets the symbol of the Token.
        /// </summary>
        [HttpGet("symbol")]
        public async Task<ApiResponse> GetSymbol()
        {
            var symbol = await _fluxTokenService.SymbolQueryAsync();
            return new ApiResponse(symbol);
        }

        /// <summary>
        /// Gets the number of decimals in Token
        /// </summary>
        [HttpGet("decimals")]
        public async Task<ApiResponse> GetDecimals()
        {
            var decimals = await _fluxTokenService.DecimalsQueryAsync();
            var decimalsBytes = new byte[] { decimals };
            return new ApiResponse((new BigInteger(decimalsBytes)).ToString());
        }

        /// <summary>
        /// Gets the total supply of Tokens
        /// </summary>
        [HttpGet("total_supply")]
        public async Task<ApiResponse> GetTotalSupply()
        {
            var totalSupply = await _fluxTokenService.TotalSupplyQueryAsync();
            return new ApiResponse(totalSupply.ToString());
        }

        /// <summary>
        /// Gets the Flux Token balance
        /// </summary>
        [HttpGet("balance/{owner}")]
        public async Task<ApiResponse> GetBalance([FromRoute]string owner)
        {
            var balance = await _fluxTokenService.BalanceOfQueryAsync(owner);
            return new ApiResponse(balance.ToString());
        }

        /// <summary>
        /// checks the amount of tokens that an owner allowed to a spender.
        /// </summary>
        [HttpPost("allowance")]
        public async Task<ApiResponse> Allowance([FromBody] CreateAllowanceRequest request)
        {
            var allowance = await _fluxTokenService.AllowanceQueryAsync(new AllowanceFunction {
                Owner = request.Owner,
                Spender = request.Spender
            });
            return new ApiResponse(allowance.ToString());
        }

        /// <summary>
        /// Transfers token to a specific address.
        /// </summary>
        [HttpPost("transfer")]
        public async Task<ApiResponse> Transfer([FromBody] CreateTransferRequest request)
        {
            var transferReceipt = await _fluxTokenService.TransferRequestAndWaitForReceiptAsync(new TransferFunction {
                To = request.To,
                Value = BigInteger.Parse(request.Value)
            });
            return new ApiResponse(transferReceipt);
        }

        [HttpPost("approve")]
        public async Task<ApiResponse> Approve([FromBody] CreateApproveRequest request)
        {
            var approveReceipt = await _fluxTokenService.ApproveRequestAndWaitForReceiptAsync(new ApproveFunction {
                Spender = request.Spender,
                Value = BigInteger.Parse(request.Value)
            });
            return new ApiResponse(approveReceipt.TransactionHash);
        }

        /// <summary>
        /// Transfers tokens from one address to another
        /// </summary>
        [HttpPost("transfer_from")]
        public async Task<ApiResponse> TransferFrom([FromBody] CreateTransferFromRequest request)
        {
            var transferFromReceipt = await _fluxTokenService.TransferFromRequestAndWaitForReceiptAsync(new TransferFromFunction
            {
                From = request.From,
                To = request.To,
                Value = BigInteger.Parse(request.Value)
            });
            return new ApiResponse(transferFromReceipt.TransactionHash);
        }

        /// <summary>
        /// Increase the amount of tokens that an owner allowed to a spender.
        /// </summary>
        [HttpPost("allowance/increase")]
        public async Task<ApiResponse> IncreaseAllowance([FromBody] CreateModifyAllowanceRequest request)
        {
            var response = await _fluxTokenService.IncreaseAllowanceRequestAndWaitForReceiptAsync(new IncreaseAllowanceFunction
            {
                Spender = request.Spender,
                AddedValue = BigInteger.Parse(request.Value)
            });
            return new ApiResponse(response.TransactionHash);
        }

        /// <summary>
        /// Decrease the amount of tokens that an owner allowed to a spender.
        /// </summary>
        [HttpPost("allowance/decrease")]
        public async Task<ApiResponse> DecreaseAllowance([FromBody] CreateModifyAllowanceRequest request)
        {
            var response = await _fluxTokenService.DecreaseAllowanceRequestAndWaitForReceiptAsync(new DecreaseAllowanceFunction
            {
                Spender = request.Spender,
                SubtractedValue = BigInteger.Parse(request.Value)
            });
            return new ApiResponse(response.TransactionHash);
        }

        /// <summary>
        /// Infura testing actions
        /// </summary>
        [HttpGet("infura/balance/{address}")]
        public async Task<ApiResponse> GetBalanceFromInfura([FromRoute] string address)
        {
            var web3 = new Web3Geth("https://ropsten.infura.io/v3/4d86f0f263a847209212303805f5b104");
            var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
            var etherAmount = Web3.Convert.FromWei(balance);
            return new ApiResponse(etherAmount);
        }
    }
}