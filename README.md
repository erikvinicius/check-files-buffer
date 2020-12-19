# Check Files Buffer
tool created to check if the buffer of two files are equal<br>
it checks the entire file buffer, checking for invalid byte by byte and returning the offset from where the files are different

## Example:

1. Creating a text file and typing anything inside, and making the copy of the same file and throwing the two in the tool through drag and drop the return will be [Sucess](https://github.com/erikvinicius/check-files-buffer/blob/master/README.md#success)

2. Now if you go to the copy of the file you created and add one more letter than the other file it will return [Length Invalid](https://github.com/erikvinicius/check-files-buffer/blob/master/README.md#length-invalid)

3. Now if you create a new copy of the file just like the original and change a single letter
example: in the original file it says "no-content" and in the copy you change a letter to "n1-content"
it will return [Buffer Invalid](https://github.com/erikvinicius/check-files-buffer/blob/master/README.md#buffer-invalid)

## Results:

### Success
<div>
  <p>If everything goes OK it will display a success message on the console.</p>
  <img src="./assets/success.png"/>
</div>

### Buffer Invalid
<div>
  <p>It will check that all bytes of the files are the same. otherwise it will display this error message.</p>
  <img src="./assets/offset-invalid.png"/>
</div>

### Length Invalid
<div>
  <p>It will check the file sizes to see if they are the same, otherwise it will display the following error message.</p>
  <p><img src="./assets/length-not-equals.png"/></p>
</div>
