#!/usr/bin/env python3
"""Validate XML well-formedness for Defs XML files in this mod workspace.

Usage: python .rw_validate_xml.py
"""
import sys
from pathlib import Path
import xml.etree.ElementTree as ET

root = Path(__file__).resolve().parent
patterns = [
    "**/Defs/*.xml",
    "**/Defs/**/*.xml",
]

failed = []
checked = 0
for pattern in patterns:
    for p in root.glob(pattern):
        # skip hidden, backups or build output elsewhere if needed
        if p.name.startswith('.'):
            continue
        checked += 1
        try:
            ET.parse(p)
        except ET.ParseError as e:
            failed.append((p, str(e)))

print(f"Checked {checked} XML files")
if not failed:
    print("All files are well-formed XML.")
    sys.exit(0)

print("Malformed XML files:")
for p, err in failed:
    print(f"- {p}: {err}")

sys.exit(2)
#!/usr/bin/env python3
import sys
import xml.etree.ElementTree as ET
import glob

root = '.'
paths = glob.glob('**/Defs/**/*.xml', recursive=True)
errors = []
for p in paths:
    try:
        ET.parse(p)
    except Exception as e:
        errors.append((p, str(e)))

if errors:
    print('FAIL', len(errors), 'files with parse errors')
    for p, e in errors:
        print(p, '-', e)
    sys.exit(1)
else:
    print('OK - All scanned Defs XML are well-formed')
    sys.exit(0)
