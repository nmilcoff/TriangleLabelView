**Note:** This repository contains a port to C# of the original library, which is written in Java.

TriangleLabelView
====================
A small widget that makes it super easy way to display a triangle label!

[![Build Status](https://www.bitrise.io/app/fbf198dfa6849f1e/status.svg?token=tDd46KxzuM5vfLWp06yC1A&branch=master)](https://www.bitrise.io/app/fbf198dfa6849f1e/status.svg?token=tDd46KxzuM5vfLWp06yC1A&branch=master)



<img src=https://github.com/shts/TriangleLabelView/blob/master/img/capture.png width="300" />


# Contents
1. [Features](#features)
2. [Installation](#installation)
3. [Supported OS & SDK versions](#supported-versions)
4. [Usage](#usage)
5. [Customising](#customising)
6. [License](#license)
7. [Credits](#credits)


## <a name="features"> Features </a>

- [x] Right triangle with four edges support (top-left, top-right, bottom-left, bottom-right)
- [x] Visual changes in runtime
- [x] Two labels support
- [x] Highly customizable 
- [x] Written in c#!

## <a name="installation"> Installation </a>

TBA

## <a name="supported-versions"> Supported OS & SDK versions </a>

Android API lvl 1 ++

## <a name="usage"> Usage </a>

To see how the TriangleLabelView are added to your xml layouts, check the sample project.

```
<jp.shts.android.library.TriangleLabelView
    android:layout_width="match_parent"
    android:layout_height="match_parent"
    android:layout_alignParentLeft="true"
    android:layout_alignParentTop="true"
    app:backgroundColor="@color/yellow_900"
    app:corner="leftTop"
    app:labelBottomPadding="5dp"
    app:labelCenterPadding="0dp"
    app:labelTopPadding="10dp"
    app:primaryText="New"
    app:primaryTextColor="@color/yellow_500"
    app:primaryTextSize="16sp"
    app:secondaryText="01"
    app:secondaryTextColor="@color/yellow_100"
    app:secondaryTextSize="11sp" />

```

## <a name="customising"> Customising </a>

In order to customise the TriangleLabelView appearance, you can play with the following attributes:

| Property   | Type | xaml name |       Description      | 
|----------|----|----|------------|
|`TopPadding`|float|`labelTopPadding`| Padding between top and first label |
|`CenterPadding`|float|`labelCenterPadding`| Padding between first and second label |
|`BottomPadding`|float|`labelBottomPadding`| Padding between second label and bottom |
|`PrimaryText`|float|`primaryText`| Text for the bottom label |
|`SecondaryText`|float|`secondaryText`| Text for the top label |
|`PrimaryTextColor`|Android.Graphics.Color|`primaryTextColor`| Text color for the bottom label |
|`SecondaryTextColor`|Android.Graphics.Color|`secondaryTextColor`| Text color for the top label |
|`PrimaryTextSize`|float|`primaryTextSize`| Text size for the bottom label |
|`SecondaryTextSize`|float|`secondaryTextSize`| Text size for for the top label |
|`TriangleBackgroundColor`|float|`backgroundColor`| Background color for the triangle view |
|`Corner`|Corner (enum)|`corner`| Values: `leftTop`, `rightTop`, `leftBottom`, `rightBottom`. Sets the corner for the triangle view |

## <a name="license"> License </a>

    Copyright (C) 2018 Nicolas Milcoff
    Copyright (C) 2016 Shota Saito

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

         http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.


## <a name="credits"> Credits </a>

The original library used [LabelView](https://github.com/corerzhang/LabelView) library by [Corer](https://github.com/corerzhang) as a base for development.