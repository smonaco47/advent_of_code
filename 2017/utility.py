def hasDuplicates(listToCheck):
  seen = {}
  for x in listToCheck:
    if x in seen: return True
    seen[x] = 1
  return False