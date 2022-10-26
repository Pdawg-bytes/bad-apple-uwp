<p align="center">
  <img src="https://user-images.githubusercontent.com/83825746/197894135-76f24a3d-5a62-4989-a2da-0add0a2c3a30.png">
</p>

# bad-apple-uwp
This is my implementation of Bad Apple, all on XAML and C#. This works by taking each frame, and then applying it as a background of a control. It sounds very impractical, but that's the point! It was a quick project, but I just wanted to make a quick implementation of my own. This is a normal UWP app with WinUI 2.8 installed.

# Limitations
You may notice that the images are very low quality, and the framerate is very low (~15fps). This is because the uncompressed frame data at full resolution takes up ~2 GB! This is way too much to package into an app, so I decided to reduce the amount of frames, and also scale down the frames to compress them all the way down to 5MB in total! This is the reason why it's so low quality.

# Building
To build this app, just install Visual Studio 2022 and the UWP workload for C#.

# Installing
Download the zip from releases, install the certificate in the downloaded zip to Local Machine > Trusted People, then, double click the APPX or MSIX file and click "install".

# !!FLASH WARNING!!
Just be sure, before downloading this app, that you have no signs of epilepsy or any other mental condition that can cause harm based on flashing content. Due to the way XAML works, and how the image is processed, this flashing cannot be mitigated, so please, be careful.

# Screenshots
![image](https://user-images.githubusercontent.com/83825746/197901719-336e92ff-1634-4012-a4e9-e1901d878ac8.png)
![image](https://user-images.githubusercontent.com/83825746/197901752-f8184639-f3f6-4e21-b272-9676b7b6106f.png)
![image](https://user-images.githubusercontent.com/83825746/197901857-ce2d87a3-8289-405d-86e0-f2e03d496edd.png)

# Demo
https://www.youtube.com/watch?v=4c1VfQGNsR8
