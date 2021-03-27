using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace FluxToken.Contracts.Ethereum
{


    public partial class FluxTokenDeployment : FluxTokenDeploymentBase
    {
        public FluxTokenDeployment() : base(BYTECODE) { }
        public FluxTokenDeployment(string byteCode) : base(byteCode) { }
    }

    public class FluxTokenDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "60806040523480156200001157600080fd5b506200003933620000256012600a6200017c565b620000339061271062000264565b6200003f565b6200029c565b806200004a57600080fd5b6200006681600254620000ee60201b620005bb1790919060201c565b6002556001600160a01b0382166000908152602081815260409091205462000099918390620005bb620000ee821b17901c565b6001600160a01b038316600081815260208181526040808320949094559251848152919290917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35050565b600080620000fd838562000114565b9050838110156200010d57600080fd5b9392505050565b600082198211156200012a576200012a62000286565b500190565b80825b600180861162000143575062000173565b81870482111562000158576200015862000286565b808616156200016657918102915b9490941c93800262000132565b94509492505050565b60006200010d600019848460008262000198575060016200010d565b81620001a7575060006200010d565b8160018114620001c05760028114620001cb57620001ff565b60019150506200010d565b60ff841115620001df57620001df62000286565b6001841b915084821115620001f857620001f862000286565b506200010d565b5060208310610133831016604e8410600b841016171562000237575081810a8381111562000231576200023162000286565b6200010d565b6200024684848460016200012f565b8086048211156200025b576200025b62000286565b02949350505050565b600081600019048311821515161562000281576200028162000286565b500290565b634e487b7160e01b600052601160045260246000fd5b6108c280620002ac6000396000f3fe608060405234801561001057600080fd5b50600436106100b45760003560e01c80633950935111610071578063395093511461016157806370a082311461017457806395d89b4114610187578063a457c2d7146101a9578063a9059cbb146101bc578063dd62ed3e146101cf576100b4565b806306fdde03146100b9578063095ea7b3146100f757806318160ddd1461011a57806323b872dd1461012c5780632ff2e9dc1461013f578063313ce56714610147575b600080fd5b6100e16040518060400160405280600981526020016823363abc2a37b5b2b760b91b81525081565b6040516100ee91906106c1565b60405180910390f35b61010a610105366004610698565b610208565b60405190151581526020016100ee565b6002545b6040519081526020016100ee565b61010a61013a36600461065d565b610282565b61011e6103e1565b61014f601281565b60405160ff90911681526020016100ee565b61010a61016f366004610698565b6103fc565b61011e610182366004610611565b610496565b6100e16040518060400160405280600381526020016208c98b60eb1b81525081565b61010a6101b7366004610698565b6104b5565b61010a6101ca366004610698565b6104f8565b61011e6101dd36600461062b565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b60006001600160a01b03831661021d57600080fd5b3360008181526001602090815260408083206001600160a01b03881680855290835292819020869055518581529192917f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591015b60405180910390a350600192915050565b6001600160a01b0383166000908152602081905260408120548211156102a757600080fd5b6001600160a01b03841660009081526001602090815260408083203384529091529020548211156102d757600080fd5b6001600160a01b0383166102ea57600080fd5b6001600160a01b03841660009081526020819052604090205461030d90836105d7565b6001600160a01b03808616600090815260208190526040808220939093559085168152205461033c90836105bb565b6001600160a01b0380851660009081526020818152604080832094909455918716815260018252828120338252909152205461037890836105d7565b6001600160a01b03858116600081815260016020908152604080832033845282529182902094909455518581529186169290917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35060015b9392505050565b6103ed6012600a610772565b6103f990612710610840565b81565b60006001600160a01b03831661041157600080fd5b3360009081526001602090815260408083206001600160a01b038716845290915290205461043f90836105bb565b3360008181526001602090815260408083206001600160a01b038916808552908352928190208590555193845290927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b9259101610271565b6001600160a01b0381166000908152602081905260409020545b919050565b60006001600160a01b0383166104ca57600080fd5b3360009081526001602090815260408083206001600160a01b038716845290915290205461043f90836105d7565b3360009081526020819052604081205482111561051457600080fd5b6001600160a01b03831661052757600080fd5b3360009081526020819052604090205461054190836105d7565b33600090815260208190526040808220929092556001600160a01b0385168152205461056d90836105bb565b6001600160a01b038416600081815260208181526040918290209390935551848152909133917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9101610271565b6000806105c88385610714565b9050838110156103da57600080fd5b6000828211156105e657600080fd5b60006105f2838561085f565b949350505050565b80356001600160a01b03811681146104b057600080fd5b600060208284031215610622578081fd5b6103da826105fa565b6000806040838503121561063d578081fd5b610646836105fa565b9150610654602084016105fa565b90509250929050565b600080600060608486031215610671578081fd5b61067a846105fa565b9250610688602085016105fa565b9150604084013590509250925092565b600080604083850312156106aa578182fd5b6106b3836105fa565b946020939093013593505050565b6000602080835283518082850152825b818110156106ed578581018301518582016040015282016106d1565b818111156106fe5783604083870101525b50601f01601f1916929092016040019392505050565b6000821982111561072757610727610876565b500190565b80825b600180861161073e5750610769565b81870482111561075057610750610876565b8086161561075d57918102915b9490941c93800261072f565b94509492505050565b60006103da600019848460008261078b575060016103da565b81610798575060006103da565b81600181146107ae57600281146107b8576107e5565b60019150506103da565b60ff8411156107c9576107c9610876565b6001841b9150848211156107df576107df610876565b506103da565b5060208310610133831016604e8410600b8410161715610818575081810a8381111561081357610813610876565b6103da565b610825848484600161072c565b80860482111561083757610837610876565b02949350505050565b600081600019048311821515161561085a5761085a610876565b500290565b60008282101561087157610871610876565b500390565b634e487b7160e01b600052601160045260246000fdfea2646970667358221220891c0c74ef7fbe5763c10bac6df3b76d273ed3af4d7e47a0d36235fb1964214f64736f6c63430008030033";
        public FluxTokenDeploymentBase() : base(BYTECODE) { }
        public FluxTokenDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class INITIAL_SUPPLYFunction : INITIAL_SUPPLYFunctionBase { }

    [Function("INITIAL_SUPPLY", "uint256")]
    public class INITIAL_SUPPLYFunctionBase : FunctionMessage
    {

    }

    public partial class AllowanceFunction : AllowanceFunctionBase { }

    [Function("allowance", "uint256")]
    public class AllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2)]
        public virtual string Spender { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve", "bool")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class DecimalsFunction : DecimalsFunctionBase { }

    [Function("decimals", "uint8")]
    public class DecimalsFunctionBase : FunctionMessage
    {

    }

    public partial class DecreaseAllowanceFunction : DecreaseAllowanceFunctionBase { }

    [Function("decreaseAllowance", "bool")]
    public class DecreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "subtractedValue", 2)]
        public virtual BigInteger SubtractedValue { get; set; }
    }

    public partial class IncreaseAllowanceFunction : IncreaseAllowanceFunctionBase { }

    [Function("increaseAllowance", "bool")]
    public class IncreaseAllowanceFunctionBase : FunctionMessage
    {
        [Parameter("address", "spender", 1)]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "addedValue", 2)]
        public virtual BigInteger AddedValue { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFunction : TransferFunctionBase { }

    [Function("transfer", "bool")]
    public class TransferFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 2)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom", "bool")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3)]
        public virtual BigInteger Value { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "spender", 2, true )]
        public virtual string Spender { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "value", 3, false )]
        public virtual BigInteger Value { get; set; }
    }

    public partial class INITIAL_SUPPLYOutputDTO : INITIAL_SUPPLYOutputDTOBase { }

    [FunctionOutput]
    public class INITIAL_SUPPLYOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

    [FunctionOutput]
    public class AllowanceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

    [FunctionOutput]
    public class DecimalsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }





    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
