
# Huffman Coding

Huffman Coding is a technique of compressing data to reduce its size without losing any of the details. It was first developed by David Huffman.

Huffman Coding is generally useful to compress the data in which there are frequently occurring characters. 

## Authors

- [@Cameliuu](https://www.github.com/Cameliuu)


## Badges



![size](https://img.shields.io/github/repo-size/Cameliuu/huffman-coding)

![lines](https://img.shields.io/tokei/lines/github/Cameliuu/huffman-coding)

![contributors](https://img.shields.io/github/contributors/Cameliuu/huffman-coding)

# Algorithm

## Steps
1. Calculate the frequency of each character in the string. 

2. Sort the characters in increasing order of the frequency. These are stored in a priority queue Q.

3. Make each unique character as a leaf node.

4. Create an empty node z. Assign the minimum frequency to the left child of z and assign the second minimum frequency to the right child of z. Set the value of the z as the sum of the above two minimum frequencies. 

5. Remove these two minimum frequencies from Q and add the sum into the list of frequencies (* denote the internal nodes in the figure above).

6. Insert node z into the tree

7. Repeat steps 3 to 5 for all the characters. 
8. For each non-leaf node, assign 0 to the left edge and 1 to the right edge. 

## Statistics

The time complexity for encoding each unique character based on its frequency is O(nlog n).

Extracting minimum frequency from the priority queue takes place 2*(n-1) times and its complexity is O(log n). Thus the overall complexity is O(nlog n).

## Applications

Huffman coding is used in conventional compression formats like GZIP, BZIP2, PKZIP, etc.

For text and fax transmissions.

## Prerequisites
* [Docker Desktop](https://www.docker.com/)
## Deployment
To deploy this project run

```bash
  docker run --rm -it camilatron/huffman
```

