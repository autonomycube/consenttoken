using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using FluxToken.Contracts.Ethereum;
using Nethereum.RPC.Eth.DTOs;

namespace FluxToken.Services.Abstract
{
    public interface IFluxTokenService
    {
        Task<BigInteger> INITIAL_SUPPLYQueryAsync(INITIAL_SUPPLYFunction iNITIAL_SUPPLYFunction, BlockParameter blockParameter = null);
        Task<BigInteger> INITIAL_SUPPLYQueryAsync(BlockParameter blockParameter = null);
        Task<BigInteger> AllowanceQueryAsync(AllowanceFunction allowanceFunction, BlockParameter blockParameter = null);
        Task<BigInteger> AllowanceQueryAsync(string owner, string spender, BlockParameter blockParameter = null);
        Task<string> ApproveRequestAsync(ApproveFunction approveFunction);
        Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null);
        Task<string> ApproveRequestAsync(string spender, BigInteger value);
        Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string spender, BigInteger value, CancellationTokenSource cancellationToken = null);
        Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null);
        Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null);
        Task<byte> DecimalsQueryAsync(DecimalsFunction decimalsFunction, BlockParameter blockParameter = null);
        Task<byte> DecimalsQueryAsync(BlockParameter blockParameter = null);
        Task<string> DecreaseAllowanceRequestAsync(DecreaseAllowanceFunction decreaseAllowanceFunction);
        Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(DecreaseAllowanceFunction decreaseAllowanceFunction, CancellationTokenSource cancellationToken = null);
        Task<string> DecreaseAllowanceRequestAsync(string spender, BigInteger subtractedValue);
        Task<TransactionReceipt> DecreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger subtractedValue, CancellationTokenSource cancellationToken = null);
        Task<string> IncreaseAllowanceRequestAsync(IncreaseAllowanceFunction increaseAllowanceFunction);
        Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(IncreaseAllowanceFunction increaseAllowanceFunction, CancellationTokenSource cancellationToken = null);
        Task<string> IncreaseAllowanceRequestAsync(string spender, BigInteger addedValue);
        Task<TransactionReceipt> IncreaseAllowanceRequestAndWaitForReceiptAsync(string spender, BigInteger addedValue, CancellationTokenSource cancellationToken = null);
        Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null);
        Task<string> NameQueryAsync(BlockParameter blockParameter = null);
        Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null);
        Task<string> SymbolQueryAsync(BlockParameter blockParameter = null);
        Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null);
        Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null);
        Task<string> TransferRequestAsync(TransferFunction transferFunction);
        Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(TransferFunction transferFunction, CancellationTokenSource cancellationToken = null);
        Task<string> TransferRequestAsync(string to, BigInteger value);
        Task<TransactionReceipt> TransferRequestAndWaitForReceiptAsync(string to, BigInteger value, CancellationTokenSource cancellationToken = null);
        Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction);
        Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null);
        Task<string> TransferFromRequestAsync(string from, string to, BigInteger value);
        Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger value, CancellationTokenSource cancellationToken = null);
    }
}