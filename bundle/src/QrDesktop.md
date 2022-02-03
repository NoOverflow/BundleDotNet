# Using that library in a .NET MAUI App

## Resources:

*MAUI (Xamarin) + UI:*
- [What is MAUI?](https://docs.microsoft.com/fr-fr/dotnet/maui/what-is-maui)
- [Introduction to XAML](https://docs.microsoft.com/en-us/dotnet/maui/xaml/)
- [Entry Control](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/text/entry)
- [Button Control](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/button)
- [GraphicsView Control](https://docs.microsoft.com/en-us/dotnet/maui/user-interface/controls/graphicsview)

*Image treatment:*
- [Image treatment with MAUI graphics](https://docs.microsoft.com/en-us/dotnet/maui/user-interface/graphics/images)

## Creating a .NET MAUI Project
Congratulations on coding that library ! Now a library in itself is good but using it in an application may be a bit better, right ?

*Introducing **QrGenerator2022**, the best QR Code generator on desktop for the year 2022 (yes this is the best name I could come up with)*

For this purpose, we'll use .NET MAUI, as I said earlier, this is a multiplatform framework allowing us to use .NET to create user applications on many platforms such as Windows, Mac, Android and IOS.

To create a project along with your library, right click on your Solution in the Solution Explorer (Panel on the right) then click on "Add > New Project", select a .NET MAUI App (Preview) and name it QrGenerator2022.

You should see the project appears in the same panel.

## Adding a dependency to a local .NET Library

Now we want to use QrLib in that new program in order to generate Qr codes,
since QrLib is in the same "Solution" (Bundle of projects), we don't need NuGet.
Instead, deploy **QrGenerator2022** in the solution explorer panel and right click the **Dependencies** tab, from there click **Add project reference** and select **QrLib**, finish by pressing Ok.

You are now able to use any public function exported by QrLib inside your project, you don't have to worry about any platform, everything is taken care of by the .NET Framework.

## Creating your first view

Now, let's see how we can design a "View" (Interface) to generate a test QR Code.
Creating views in .NET MAUI is done through a markup language called XAML (Although you can create your UIs by going only-code), I've linked some useful tutorials in the "Resources" section above.

Start by running the sample program, to do so right click on it and *Set as startup project* then press F5 or the play button. Now open the MainPage.xaml file to try and figure out how it the UI is rendered from XAML. Using this and the documentation online, you should be able to complete the following tasks.

### Tasks:
- [ ] Remove the sample UI (You can keep the grid layout or use your own)
- [ ] Add an *Entry* element (It's a fancy textbox), so that the user can input the QR text.
- [ ] Add a button that triggers the QR Code generation, for now, just create the button *Clicked* handler and leave it as-is in the code.
- [ ] Add a *GraphicsView* element that will be later used to draw the generated QR code, make sure to give it a size !
- [ ] Try and make the UI good looking, it's always nice

## Adding logic to your view

**Disclaimer:**
*Usually, you design your program by following a pattern (MVVM for example) but for the sake of simplicity we'll do it the dirty way here.*

Now that we have our fancy UI, let's make it do something useful. If you followed properly, your button should now have a *Clicked* handler in the code (If you can't find code, deploy the MainPage.xaml on the right and click the .cs file, that's the code-behind).

It's up to you to code this button logic, here's what it should do (feel free to export this in another function and call it from the handler):

### Tasks:
- [ ] Check if the entered text is null
- [ ] Create a QrGenerator from QrLib, (you may have to add a using statement)
- [ ] Generate a QR from the entry text by calling QrGenerator.FromText()
- [ ] (*Wait for next step*) Pass the byte[] to your Drawable class
- [ ] (*Wait for next step*) Invalidate the GraphicsView so that it is redrawn

You now have a byte[] representing the image data, you need to convert it to an actual Image object, then draw it on a canvas. To perform these actions you'll need to be inside a graphical-context.

## Creating your graphical context

Create a class called **QrDrawable** in the MainPage.xaml.cs file, this class is your graphical context and will be used to render the QR code, this class MUST implement **IDrawable** (Visual studio can do it for you if you haven't figured it out yet, just right click on the error line and then click on the lightbulb).

Add a public property to this class with a byte[] type and set its default value to null (Check how-to in the resources). This property will be used to pass the byte array between the graphical context and the view-code.

Go back to the previous tasks, you should now be able to pass the byte[] and call the Invalidate function on your GraphicsView.

You can go then ahead and code the **Draw()** (implementing **IDrawable**) function logic so that it performs the following tasks:

### Tasks:
- [ ] Check if the byte[] property is not null
- [ ] Create a MemoryStream from it and call GraphicsPlatform.CurrentService.LoadImageFromStream to get an image from it
- [ ] Draw the resulting image on the canvas (Check the resources)

## You should be done, congrats

If you did everything properly, you can now start your MAUI program, enter text in your entry and click the generate button, you should get a nice looking QR Code. Go ahead and scan it ! You can be proud (and you can go back later on if you want to add features such as generating from a phone number and such.)

If not, go back and figure out what's wrong, you can use breakpoints by pressing F9 and hover any variable to check its value during runtime. Make sure that the button press calls the handler.
