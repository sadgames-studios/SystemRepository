# System Repository

This repository contains a basic implementation of a system repository for managing components in an application.

## Description

The system repository provides a way to register, retrieve, and remove components in an application. Components should extend the `IComponent` interface.

## Usage
### Registering Components

To register a new component in the system, use the `Register<T>()` method of the `SystemRepository`. For example:

```csharp
SystemRepository.Register<TestComponent>(new TestComponent());
