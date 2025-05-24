# S03 API Architecture
	Introduction

## S03 E018: Introduction
	Introduction
	Application architecture
	The Repository Pattern
	Seeding Data
	Migrations and Startup

## S03 E019: Introduction to the Repository Pattern
	Decouple business code from data access
	Separation of concerns
		avoid direct use of dbcontext
	Minimise duplciate query logic
		context accross different controllers
	Testability

	Avoid messy controller
	Simplified testing
	Increased abstraction
	Maintainability
	Reduced duplicate code

	Abstraction of an abstraction
	Optimization challenge

	IRepository GetProduct GetProducts
		Controller GetProducts()
			Repository _context.Products.ToList()
				DbContext SELECT * FROM PRODUCTS

## S03 E020 Creating the Repository Interface and Implemention

## S03 E021 Implementing the Repository Methods

## S03 E022 Using the repository in the controller

## S03 E023 Seeding data

## S03 E024 Getting the brands and types

## S03 E025 Filtering the products by brand

## S03 E026 Sorting the products

## S03 E027 Summary
