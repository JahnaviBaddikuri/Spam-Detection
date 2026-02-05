# Spam-Detection
The Spam Text Classifier is a web-based application designed to automatically detect and classify SMS messages as "Spam" or "Not Spam" using machine learning techniques. . The system is built using Python, Flask, and scikit-learn, and features a simple user interface for manual input as well as a RESTful API for integration with other systems.


# SMS & Email Spam Text Classifier

A Python-based web application that uses machine learning to detect whether a given text message is spam or not. This project migrates the original C# .NET-based spam classifier to Python using Flask and scikit-learn.

## Features

- Web-based interface for easy spam detection
- Machine learning model trained on SMS spam dataset
- Real-time spam classification with probability
- Clean and intuitive user interface with background image
- REST API endpoint for programmatic access

## Prerequisites

Before running this project, ensure you have the following installed:

- Python 3.8 or higher
- pip (Python package manager)

## Installation

1. **Clone the repository**:
   ```bash
   git clone https://github.com/yourusername/SpamTextClassifierPy.git
   cd SpamTextClassifierPy
   ```

2. **Create a virtual environment**:
   ```bash
   python -m venv venv
   ```

3. **Activate the virtual environment**:
   - On Windows:
     ```bash
     .\venv\Scripts\activate
     ```
   - On macOS/Linux:
     ```bash
     source venv/bin/activate
     ```

4. **Install required dependencies**:
   ```bash
   pip install -r requirements.txt
   ```

## Running the Project

1. **Ensure the virtual environment is activated**:
   ```bash
   .\venv\Scripts\activate
   ```

2. **Run the Flask application**:
   ```bash
   python app.py
   ```

3. **Access the application**:
   - Open your web browser and navigate to:
     ```
     http://127.0.0.1:5000/
     ```

4. **Use the application**:
   - Enter a text message in the textarea
   - Click "Check for Spam" button
   - The application will display whether the text is spam or not with a probability score

## Project Structure

```
SpamTextClassifierPy/
├── app.py                    # Flask application
├── train_model.py            # Script to train the ML model
├── requirements.txt          # Python dependencies
├── model.pkl                 # Trained ML model
├── vectorizer.pkl            # Text vectorizer for preprocessing
├── SMSSpamCollection.txt     # Training dataset
├── templates/
│   └── index.html            # Web interface HTML
├── static/
│   └── images/
│       └── background.jpeg   # Background image
└── WebAppReference/          # Reference files from original C# project
    ├── Index.cshtml
    └── HomeController.cs
```

## Model Training

The model is trained using the SMS Spam Collection dataset. To retrain the model:

```bash
python train_model.py
```

This script will:
1. Load the SMS Spam Collection dataset
2. Preprocess the text data
3. Train a Naive Bayes classifier
4. Save the model and vectorizer to `model.pkl` and `vectorizer.pkl`

## Technologies Used

- **Framework**: Flask (Python web framework)
- **Machine Learning**: scikit-learn
- **Data Processing**: pandas, numpy
- **Model Serialization**: joblib
- **Frontend**: HTML, CSS, JavaScript

## Dataset

The project uses the SMS Spam Collection dataset, which contains:
- Total messages: 5,574
- Ham messages: 4,827
- Spam messages: 747
