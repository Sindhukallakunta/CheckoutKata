# Checkout Kata

This repository contains a C# implementation of the Checkout Kata problem using a Test-Driven Development (TDD) approach with NUnit and the Strategy design pattern.

---

## Problem Summary

- Items are identified by SKUs (A, B, C, D, etc.)
- Each SKU has a unit price
- Some SKUs support special pricing rules (e.g. multi-buy, buy-one-get-one)
- The checkout accepts items in any order
- Pricing rules may change frequently

The checkout must accept items in any order and total the price according to the pricing rules.

---

## Design Overview

### Checkout

`Checkout` is responsible for:
- Accepting scanned items
- Validating input (null, empty, unknown SKU)
- Calculating the final total using pricing strategies

`Checkout` does not contain pricing logic itself.  
It delegates pricing behaviour to injected pricing rules.

---

### Pricing Rules (Strategy Pattern)

Pricing is implemented using the Strategy Pattern via the `IPricingRule` abstraction.

Each pricing rule:
- Represents pricing logic for a single SKU
- Exposes its SKU via the `Sku` property
- Calculates its contribution to the total price

Current pricing strategies include:
- Unit price
- Multi-buy pricing
- Buy one get one free
- Percentage discount

Adding a new pricing rule requires:
1. Creating a new implementation of `IPricingRule`
2. Registering it when constructing `Checkout`

No changes to `Checkout` are required.

---

## Test Strategy

The solution follows the **Red ? Green ? Refactor** cycle:

1. A failing test is written (Red)
2. Production code is added to satisfy the test (Green)
3. Refactoring improves design while keeping tests green

Tests are organized into:

- Checkout tests — verify scanning behaviours and totals
- Pricing rule tests — validate each pricing strategy

---

## Behaviour and Edge Cases

The implementation enforces:

- Scanning a null SKU throws `ArgumentNullException`
- Scanning an empty or whitespace SKU throws `ArgumentException`
- Scanning an unknown SKU throws `ArgumentException`
- Checkout must be created with at least one pricing rule
- Only one pricing rule per SKU is allowed

---

## Technology Stack

- .NET
- C#
- NUnit

---

## Running Tests

From your terminal:

```bash
dotnet test
