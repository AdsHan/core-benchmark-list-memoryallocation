using BenchmarkDotNet.Running;
using MemoryAllocation.Tests;

var summary = BenchmarkRunner.Run<ListMemoryAllocation>();

Console.Read();