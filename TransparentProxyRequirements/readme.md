## Requirements

We are implementing a tracing and logging extension based for Reactive Extensions to make the logging and diagnosis of Reactive Extensions based solutions easier. 

We already have a solution, heavily based on the work done in RxSpy, which works on Android. 

What we are looking to do now is also make this available for iOS solutions. 

## Background

All static extension methods on System.Reactive.Observable go through a private member of the Observable class that implements the private interface IQueryLanguage. 

We use private reflection to both locate and set the field but it seems impossible to create an implementation of this private IQueryLanguage without being a friend assembly to System.Reactive.Linq.

We get around this by using RealProxy https://msdn.microsoft.com/en-us/library/system.runtime.remoting.proxies.realproxy(v=vs.110).aspx, which is part of .NET remoting API and allows us to create a transparent proxy that the framework is happy to accept.

However, whilst RealProxy works fine with Android & 'normal' .NET solutions it won't work with iOS solutions, *groan*.

## How to Move Forward

So, how can we move forward?

A few options spring to mind, I don't know if any of these however are viable.

1. Get Reactive Extensions to make the IQueryLanguage interface public, this would seem to be the easiest/safest option.
2. Don't know if this is viable but - weave/adjust the existing Reactive Extensions Libraries to make the interface public?
3. Similarly, weave/Adjust the Reactive Extensions Libraries existing IQueryLanguage interface to in effect do what the StaticProxy for Fody does.


