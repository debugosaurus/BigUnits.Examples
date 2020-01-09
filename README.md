# BigUnits.Examples

Provides simple examples of using the [BigUnits](https://github.com/debugosaurus/BigUnits) library to author unit tests. The purpose being to show how the library can be used, along with hopefully showing how wider scoped tests might be useful.

The example uses a mock feature that either displays, or not, a popup message to users informing them of cookie policies. There are two separate test projects for this feature, one focusing on solitary unit tests, the other on social unit tests (big units). The key thing to note here is that both approaches are equally valid and this library is not about trying to promote one technique over another.

## Debugosaurus.BigUnits.Examples

The main feature implementation is contained within the `/CookiePopup` directory. For neatness I've separated the internal implementation types into a sub-directory, leaving the top directory to contain just the "API" and "contract" types.

Things to note:
* The `/Implementation` interfaces here only exist for the purposes of mocking within the `UnitTests` project - they could be removed if just using `BigUnitTests` project tests
* The `BOM` problem is a bit contrived - in the real world the `IFileSystem` implementation would be responsible for properly scrubbing responses

## Debugosaurus.BigUnits.Examples.UnitTests

This project tests the feature using what I'd consider a more traditional solitary unit testing approach, with each individual class having a separate test fixture covering the various paths through the code. 

**Pros:**
* Tests are more isolated from changes
* Quicker to run

**Cons:**
* Tests don't describe the feature
* Tests are more focused on implementation details<sup>\*</sup>
* Requires the generation of interfaces used only for mocking purposes

<sub>\* this is not necessarilly always a bad thing, just in this situation the code being tested has a one-to-one correspondence to a feature and should probably be tested in the context of that feature. _If_ on the other hand, we were testing the `IFileSystem` implementation, then it might make more sense to author solitary unit tests to cover the low level class requirements.</sub>

## Debugosaurus.BigUnits.Examples.BigUnitTests

In the `BigUnitTests` project there is just one fixture containing two larger scoped tests - compared to 3 fixtures and 5 tests in the other project. The tests focus on the `CookiePopupFeature` feature rather than implementation specifics.

**Pros:**
* Fewer tests for equal functional coverage (doesn't cover the BOM implementation specifics)
* Doesn't need the internal interfaces
* Tests describe feature requirements

**Cons:**
* Tests are more susceptible to changes 
* Fractionally slower to run (roughly 0.1 seconds, though not benchmarked)