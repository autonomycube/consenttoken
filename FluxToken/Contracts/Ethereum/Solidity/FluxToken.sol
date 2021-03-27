// SPDX-License-Identifier: MIT
pragma solidity ^0.8.3;

import './ERC20.sol';

/**
* @title FluxToken
* @dev Very simple ERC20 token example, where all tokens are pre-assigned to the creator.
* Note they can later distribute these tokens as they wish using `transfer` and other
* `ERC20` functions.
*/
contract FluxToken is ERC20 {
    string public constant name = "FluxToken";
    string public constant symbol = "FLX";
    uint8 public constant decimals = 18;

    uint256 public constant INITIAL_SUPPLY = 10000 * (10 ** uint256(decimals));

    /**
    * @dev Constructor that gives msg.sender all of existing tokens.
    */
    constructor() public {
        _mint(msg.sender, INITIAL_SUPPLY);
    }
}