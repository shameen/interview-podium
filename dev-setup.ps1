pushd website
Try {
  # Use global yarn
  yarn
}
Catch {
  Write-Host "Global yarn failed, attempting to run local version..."
  # Install local yarn if there isn't one
  if (!(Test-Path 'node_modules\.bin\yarn' -PathType Leaf)) {
    Write-Host "Installing yarn locally..."
    npm install yarn --no-package-lock
  }
  # Run local yarn
  .\node_modules\.bin\yarn
}
popd