# Run the app locally

npm start

# Build Docker image

docker image build -t wishlist:help .

# Run container

docker run -d -p 3002:3002 wishlist:help
