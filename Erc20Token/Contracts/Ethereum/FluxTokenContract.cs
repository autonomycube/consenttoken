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
        public static string BYTECODE = "60806040523480156200001157600080fd5b506200003933620000256012600a6200017c565b620000339061271062000264565b6200003f565b6200029c565b806200004a57600080fd5b6200006681600254620000ee60201b620005451790919060201c565b6002556001600160a01b038216600090815260208181526040909120546200009991839062000545620000ee821b17901c565b6001600160a01b038316600081815260208181526040808320949094559251848152919290917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35050565b600080620000fd838562000114565b9050838110156200010d57600080fd5b9392505050565b600082198211156200012a576200012a62000286565b500190565b80825b600180861162000143575062000173565b81870482111562000158576200015862000286565b808616156200016657918102915b9490941c93800262000132565b94509492505050565b60006200010d600019848460008262000198575060016200010d565b81620001a7575060006200010d565b8160018114620001c05760028114620001cb57620001ff565b60019150506200010d565b60ff841115620001df57620001df62000286565b6001841b915084821115620001f857620001f862000286565b506200010d565b5060208310610133831016604e8410600b841016171562000237575081810a8381111562000231576200023162000286565b6200010d565b6200024684848460016200012f565b8086048211156200025b576200025b62000286565b02949350505050565b600081600019048311821515161562000281576200028162000286565b500290565b634e487b7160e01b600052601160045260246000fd5b61084c80620002ac6000396000f3fe608060405234801561001057600080fd5b50600436106100b45760003560e01c80633950935111610071578063395093511461016157806370a082311461017457806395d89b4114610187578063a457c2d7146101a9578063a9059cbb146101bc578063dd62ed3e146101cf576100b4565b806306fdde03146100b9578063095ea7b3146100f757806318160ddd1461011a57806323b872dd1461012c5780632ff2e9dc1461013f578063313ce56714610147575b600080fd5b6100e16040518060400160405280600981526020016823363abc2a37b5b2b760b91b81525081565b6040516100ee919061064b565b60405180910390f35b61010a610105366004610622565b610208565b60405190151581526020016100ee565b6002545b6040519081526020016100ee565b61010a61013a3660046105e7565b610282565b61011e61036b565b61014f601281565b60405160ff90911681526020016100ee565b61010a61016f366004610622565b610386565b61011e61018236600461059b565b610420565b6100e16040518060400160405280600381526020016208c98b60eb1b81525081565b61010a6101b7366004610622565b61043f565b61010a6101ca366004610622565b610482565b61011e6101dd3660046105b5565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b60006001600160a01b03831661021d57600080fd5b3360008181526001602090815260408083206001600160a01b03881680855290835292819020869055518581529192917f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b92591015b60405180910390a350600192915050565b6001600160a01b0383166000908152602081905260408120548211156102a757600080fd5b6001600160a01b0383166102ba57600080fd5b6001600160a01b0384166000908152602081905260409020546102dd9083610561565b6001600160a01b03808616600090815260208190526040808220939093559085168152205461030c9083610545565b6001600160a01b038481166000818152602081815260409182902094909455518581529092918716917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef910160405180910390a35060015b9392505050565b6103776012600a6106fc565b610383906127106107ca565b81565b60006001600160a01b03831661039b57600080fd5b3360009081526001602090815260408083206001600160a01b03871684529091529020546103c99083610545565b3360008181526001602090815260408083206001600160a01b038916808552908352928190208590555193845290927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b9259101610271565b6001600160a01b0381166000908152602081905260409020545b919050565b60006001600160a01b03831661045457600080fd5b3360009081526001602090815260408083206001600160a01b03871684529091529020546103c99083610561565b3360009081526020819052604081205482111561049e57600080fd5b6001600160a01b0383166104b157600080fd5b336000908152602081905260409020546104cb9083610561565b33600090815260208190526040808220929092556001600160a01b038516815220546104f79083610545565b6001600160a01b038416600081815260208181526040918290209390935551848152909133917fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9101610271565b600080610552838561069e565b90508381101561036457600080fd5b60008282111561057057600080fd5b600061057c83856107e9565b949350505050565b80356001600160a01b038116811461043a57600080fd5b6000602082840312156105ac578081fd5b61036482610584565b600080604083850312156105c7578081fd5b6105d083610584565b91506105de60208401610584565b90509250929050565b6000806000606084860312156105fb578081fd5b61060484610584565b925061061260208501610584565b9150604084013590509250925092565b60008060408385031215610634578182fd5b61063d83610584565b946020939093013593505050565b6000602080835283518082850152825b818110156106775785810183015185820160400152820161065b565b818111156106885783604083870101525b50601f01601f1916929092016040019392505050565b600082198211156106b1576106b1610800565b500190565b80825b60018086116106c857506106f3565b8187048211156106da576106da610800565b808616156106e757918102915b9490941c9380026106b9565b94509492505050565b6000610364600019848460008261071557506001610364565b8161072257506000610364565b816001811461073857600281146107425761076f565b6001915050610364565b60ff84111561075357610753610800565b6001841b91508482111561076957610769610800565b50610364565b5060208310610133831016604e8410600b84101617156107a2575081810a8381111561079d5761079d610800565b610364565b6107af84848460016106b6565b8086048211156107c1576107c1610800565b02949350505050565b60008160001904831182151516156107e4576107e4610800565b500290565b6000828210156107fb576107fb610800565b500390565b634e487b7160e01b600052601160045260246000fdfea264697066735822122019ceca20c9379fbd4c3abf914c43551f44942b4dbc9184faa7f959bf9cea188564736f6c63430008030033";
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
