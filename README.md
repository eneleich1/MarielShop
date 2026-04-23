# MarielShop

> Legacy Xamarin.Forms prototype for a cross-platform marketplace/classifieds mobile app backed by SQLite.

MarielShop is a cross-platform mobile application built with **Xamarin.Forms** and **C#** for browsing local marketplace announcements stored in a **SQLite** database.  
It uses a shared UI/business-logic project plus platform-specific projects for **Android**, **iOS**, and **UWP**.

## Overview

This repository contains an early marketplace/classifieds app prototype focused on:

- browsing recent announcements
- reading local data from SQLite
- reusing a shared Xamarin.Forms codebase across multiple platforms
- basic app configuration for local database access

The solution is organized into:

- `MarielShop` - shared Xamarin.Forms project
- `MarielShop.Android` - Android startup project
- `MarielShop.iOS` - iOS project
- `MarielShop.UWP` - UWP project

## Features

### Implemented
- Main menu navigation
- Recent announcements page
- Local SQLite database access
- Shared announcement model
- Database path verification/configuration
- Basic image conversion support for announcement images

### Present but incomplete / disabled
- Featured announcements
- Search page
- Insert announcement flow

## Project Structure

### Shared Project (`MarielShop`)
Contains the main UI, domain model, and shared logic.

#### Core files
- `App.xaml / App.xaml.cs`  
  Application bootstrap and shared object initialization.

- `MainPage.xaml / MainPage.xaml.cs`  
  Main navigation screen with access to recent announcements, settings, and about page.

- `Models/Announcement.cs`  
  Main domain model for marketplace announcements, including:
  - title/header
  - body/description
  - location
  - price
  - category
  - currency
  - condition
  - relevance flag
  - up to 3 images

- `Controllers/AnnouncementsDB.cs`  
  SQLite data access layer used to query and read announcements.

- `Pages/Recently.xaml / Recently.xaml.cs`  
  Displays recent announcements from the SQLite database.

- `Pages/Settings.xaml / Settings.xaml.cs`  
  Lets the user validate and update the database path.

- `Pages/About.xaml / About.xaml.cs`  
  Basic informational page about the app.

- `Convertes/ImageConverter.cs`  
  Converts stored image bytes into images that can be rendered in the UI.

### Platform Projects
- `MarielShop.Android`
- `MarielShop.iOS`
- `MarielShop.UWP`

These projects host the shared Xamarin.Forms app on each platform.

## How it works

On startup, the Android project initializes shared services for:

- file system access
- message rendering
- app paths/settings

The application then checks for a local SQLite database file and allows the user to validate or update that path from the **Settings** page.

The **Recent announcements** page loads data directly from the `Announcement` table using SQLite.

## Data Layer

The app uses **SQLite** for local persistence.

Main database access responsibilities include:

- opening the local database
- reading the `Announcement` table
- running direct SQL queries
- exposing data to the UI

## Technologies Used

- **C#**
- **Xamarin.Forms**
- **XAML**
- **SQLite**
- **.NET / PCL-style shared project structure**

## Current State

This repository represents an **early-stage / in-progress prototype**, not a fully completed marketplace product.

What is clearly functional in this snapshot:
- app shell/navigation
- local DB validation
- recent announcements view
- shared model + SQLite integration

What is not fully built yet:
- full search experience
- featured announcements flow
- create/insert announcement workflow
- production-ready UX polish

## Why this project matters

MarielShop demonstrates practical experience with:

- cross-platform mobile app structure using Xamarin.Forms
- shared UI and business logic across multiple targets
- local SQLite integration in a real app scenario
- domain modeling for marketplace/classifieds data
- basic app configuration and platform startup wiring

## Notes

- The Android project contains the clearest startup/configuration flow in this repository snapshot.
- The app expects a local SQLite database file.
- Some UI labels and navigation items are in Spanish, reflecting the original target usage context.
- This project is best described as a **prototype / legacy mobile app experiment** rather than a finished commercial release.

## Status

**Archived prototype / legacy Xamarin.Forms project**
