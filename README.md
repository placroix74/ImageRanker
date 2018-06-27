# ImageRanker

## Motivation
I got stuck having to sift through hundreds of photos to select those which I thought best.
I needed a tool which could help me automate the task of comparing photos to one another.

I had found a candidate, [Ranker](https://sourceforge.net/projects/ranker/), but:
- The tool was built on top of GTKmm, which crippled my Windows system upon installation;
- The tool crashed when I tried to import images into it.

ImageRanker is built on .NET 4.5.2.

## What Should You Expect?
ImageRanker is as lean as I could make it:
- __Open/Save text-based ranking files:__ these files are simply lists of absolute image 
  pathnames, ordered by rank (highest rank first).
- __Add/Remove/Clear images from the list.__
- __Rank Images:__ You will be shown pairs of images until the ranking process is complete.

# How to use
The main form is pretty self-explanatory, as every command is listed in the menus, along 
with their shortcuts.

In the pair comparison form, however:
- Clicking on an image selects it and closes the form automatically;
- Closing the form without making a selection means the images rank equally;

The comparison form also has keyboard shortcuts:
- Pressing the Left or Right key selects the image on the left or right, respectively;
- Pressing the Escape key closes the form without making a selection.

## Technical Notes
I had started out using Quicksort and showing the pairs as they came up, but the human mind
being what it is, I could not escape [inconsistent sorting results](https://blogs.msdn.microsoft.com/oldnewthing/20090508-00/?p=18313).

So, basically:
- Each image is compared exactly once against every other ((n^2 + n) / 2 comparisons in total);
- Each image selected from a pair get a _hit_, and the final results are sorted by descending amount of hits.
