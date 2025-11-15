#!/usr/bin/env zsh
# Deploy Defs from workspace root into a mod folder (back up first).
# Usage: ./deploy_defs.sh /absolute/path/to/target/mod/folder

set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
SRC="$ROOT/Defs"

TARGET_DIR_DEFAULT="$ROOT/../1.6"
TARGET_DIR="${1:-$TARGET_DIR_DEFAULT}"

if [[ ! -d "$SRC" ]]; then
  echo "Source Defs not found: $SRC"
  exit 1
fi

if [[ ! -d "$TARGET_DIR" ]]; then
  echo "Target mod folder does not exist: $TARGET_DIR"
  exit 1
fi

DEST="$TARGET_DIR/Defs"
BACKUP="$TARGET_DIR/Defs.backup.$(date +%Y%m%d%H%M%S)"

echo "Deploying Defs from: $SRC"
echo "Target mod folder: $TARGET_DIR"

if [[ -d "$DEST" ]]; then
  echo "Backing up existing $DEST -> $BACKUP"
  mv "$DEST" "$BACKUP"
fi

echo "Copying Defs to target..."
cp -a "$SRC" "$DEST"

echo "Listing target Defs:" 
ls -la "$DEST"

echo "Deploy complete. Backup (if any): $BACKUP"
