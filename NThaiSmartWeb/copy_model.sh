#!/bin/bash

SRC_DIR="./wwwroot/face-api.js-models"
DST_DIR="./wwwroot/models"

mkdir -p "$DST_DIR"

echo "Copying .json and shard files (no extension) from $SRC_DIR to $DST_DIR"

find "$SRC_DIR" -type f \( -name "*.json" -o ! -name "*.*" \) -print0 | while IFS= read -r -d '' file; do
  cp -v "$file" "$DST_DIR"
done

echo "Copy complete."
