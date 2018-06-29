# ImageRanker

## Motivation
I got stuck having to sift through hundreds of photos to select those which I thought best.
I needed a tool which could help me automate the task of comparing photos to one another.

I had found a candidate, [Ranker](https://sourceforge.net/projects/ranker/), but:
- The tool is built on top of GTKmm, which crippled my Windows system upon installation;
- The tool crashed when I tried to import images into it.

ImageRanker is built on .NET 4.5.2.

## What Should You Expect?
ImageRanker is as lean as I could make it:

- __Open/Save text-based ranking files:__ these files are simply lists of absolute image 
  pathnames, ordered by rank (highest rank first).
- __Add/Remove/Clear images from the list.__
- __Rank Images:__ You will be shown pairs of images until the ranking process is complete.

## How to use

### Main Form
The main form is pretty self-explanatory, as every command is listed in the menus, along 
with their shortcuts.

### Pair Ranking Dialog
Progress of the ranking process appears in the title bar: "Ranking Pair X of N".

Radio buttons below the image pair show possible outcomes of the ranking:

- __Pick Both (initially selected):__ Both images are considered equivalent; not one image
  of the two registers a _hit_.
- __Pick (either side):__ The image on the same side as the radio button is considered more
  valuable that on the other side, and registers a _hit_.
- __Exclude (either side):__ The image on the same side as the radio button is excluded from
  further comparison. Note that this does _not_ contitute a hit for the image on the other side.

Clicking the "Next" button validates the selected action.

## Technical Notes
I had started out using Quicksort and showing the pairs as they came up, but the human mind
being what it is, I could not avoid [inconsistent results](https://blogs.msdn.microsoft.com/oldnewthing/20090508-00/?p=18313).

So, basically:

- Each image is compared exactly once against every other ((n^2 + n) / 2 comparisons in total);
- Each image selected from a pair registers a _hit_, and the images get sorted by descending hit count.
