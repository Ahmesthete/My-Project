#ifndef NODE_H
#define NODE_H

#include "Match.h"

// Node class for representing a single node in the tournament tree
class Node {
public:
    Match* match; // Pointer to a Match object associated with this node
    Node* left;   // Pointer to the left child node
    Node* right;  // Pointer to the right child node

    // Constructor to initialize the Node with a Match object
    // The left and right child pointers are initialized to nullptr
    Node(Match* m) : match(m), left(nullptr), right(nullptr) {}
};

#endif // NODE_H
