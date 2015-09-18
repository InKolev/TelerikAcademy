Brief overview
---------------

The ***background color switch*** can be used in many different cases. You want to make your website theme more customizable, you want to highlight on an article, function or whatever. 
We offer a clean solution using pure **jQuery**, **HTML** & **CSS**.

Step-by-step instructions
--------------------------

 1. Setup the HTML

        <label class="Form-label--tick">
            <input class="Form-label-radio" type="radio" name="background-color" value="orange"/>
            <span class="Form-label-text">Orange</span>
        </label>

        <label class="Form-label--tick">
            <input class="Form-label-radio" type="radio" name="background-color" value="blue" />
            <span class="Form-label-text">Blue</span>
    </label>

 2. Link the CSS inside the **head** tag

        <link rel="stylesheet" href="pure-css-radio-checkbox-master/dist/check-radio.css" type="text/css" />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css">

 3. Load jQuery library inside the **head** tag

        <script src="jquery-2.1.4.min.js"></script>
 4.  Load our jQuery logic at the **bottom** of the **HTML body**

        <script src="app.js"></script>

 5. Positioning the switch - You can wrap the HTML from **step 1** with a div element and then position it with CSS the way you desire.
**HTML:**

        <div class="wrapper">
        ... 
        content
        ...
        </div>

    **CSS:** (vertically and horizontally positioned)
    > .wrapper {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
}

Additional info
---------------
There is a list of all our products. You can learn more by clicking on [this link.](https://www.google.bg/)

> **TIP:** Check [this wiki article](http://learnlayout.com/position.html) for more information on positioning with CSS.

Was this article helpful to you? **Yes - No.**