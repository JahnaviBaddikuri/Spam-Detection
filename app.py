from flask import Flask, request, jsonify, render_template
import joblib
import numpy as np

# Initialize Flask app
app = Flask(__name__)

# Load the pre-trained model and vectorizer
model = joblib.load('model.pkl')
vectorizer = joblib.load('vectorizer.pkl')

@app.route('/', methods=['GET', 'POST'])
def home():
    if request.method == 'POST':
        input_text = request.form.get('input_text', '')
        if input_text:
            transformed_text = vectorizer.transform([input_text])
            prediction = model.predict(transformed_text)
            probability = model.predict_proba(transformed_text)[0][1] * 100
            is_spam = prediction[0] == 1
            return render_template('index.html', result=True, is_spam=is_spam, probability=f'{probability:.2f}', input_text=input_text)
    return render_template('index.html', result=None, input_text='')

@app.route('/predict', methods=['POST'])
def predict():
    data = request.get_json()
    text = data.get('text', '')
    # Preprocess and predict
    transformed_text = vectorizer.transform([text])
    prediction = model.predict(transformed_text)
    result = 'Spam' if prediction[0] == 1 else 'Not Spam'
    
    return jsonify({'text': text, 'prediction': result})

if __name__ == '__main__':
    app.run(debug=False)