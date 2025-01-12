const path = require('path'); // Import the 'path' module
const HtmlWebpackPlugin = require('html-webpack-plugin'); // Import HtmlWebpackPlugin
const { CleanWebpackPlugin } = require('clean-webpack-plugin'); // Clean dist folder before each build

module.exports = {
  entry: './src/index.tsx', // Entry point of your app
  output: {
    path: path.resolve(__dirname, 'dist'), // Output directory
    filename: 'main.js', // Output file name
  },
  resolve: {
    extensions: ['.ts', '.tsx', '.js', '.jsx'], // Add TypeScript and JS extensions
  },
  module: {
    rules: [
      {
        test: /\.tsx?$/, // Match TypeScript files
        use: 'ts-loader', // Use ts-loader to handle TypeScript files
        exclude: /node_modules/,
      },
      {
        test: /\.css$/, // Match CSS files
        use: ['style-loader', 'css-loader'], // Use style-loader and css-loader for CSS files
      },
    ],
  },
  plugins: [
    new CleanWebpackPlugin(), // Clean dist folder before build
    new HtmlWebpackPlugin({
      template: './src/index.html', // Generate index.html from template
      filename: 'index.html', // Output file name
    }), 
  ],
  devServer: {
    static: {
      directory: path.join(__dirname, 'dist'), // Use static instead of contentBase
    },
    compress: true,
    port: 8080,
    open: true,
    hot: true, // Enable hot module replacement
    historyApiFallback: true, // Serve index.html for all 404 routes
  },
  mode: 'development',
};
